using M15_ProjetoFutebol.Jogadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M15_ProjetoFutebol.Equipas
{
    public partial class f_equipas : Form
    {
        BaseDados bd;
        string Emblema;
        int nequipa_escolhida;
        public f_equipas(BaseDados bd)
        {
            this.bd=bd;
            InitializeComponent();
            AtualizarGrelha();
        }

        /// <summary>
        /// Selecionar Fotografia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btEscolher_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            ficheiro.Multiselect = false;
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pbemblema.Image = Image.FromFile(temp);
                    Emblema = temp;
                }
            }
        }
        private void AtualizarGrelha()
        {
            dgvEquipas.AllowUserToAddRows = false;
            dgvEquipas.AllowUserToDeleteRows = false;
            dgvEquipas.ReadOnly = true;
            dgvEquipas.DataSource = Equipa.ListarTodos(bd);
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Emblema))
            {
                MessageBox.Show("Tem de selecionar uma fotografia!");
                return;
            }
            if (txtNome.Text == "" || txtNome.Text.Length < 4)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                txtNome.Focus();
                return;
            }
            if (txtCampeonato.Text == "")
            {
                MessageBox.Show("Escreva o campeonato da Equipa.");
                txtCampeonato.Focus();
                return;
            }

            //criar jogador
            Equipa equipa = new Equipa(0, txtNome.Text, txtCampeonato.Text, Utils.ImagemParaVetor(Emblema));

            //Guardar na base de dados
            equipa.Guardar(bd);

            //limpar form
            LimparForm();

            //atualizar grid
            AtualizarGrelha();
        }

        private void LimparForm()
        {
            txtNome.Text = "";
            txtCampeonato.Text = "";
            pbemblema.Image = null;
            Emblema = "";
        }

        private void btApagar_Click(object sender, EventArgs e)
        {
            Equipa.Apagar(bd, nequipa_escolhida);
            AtualizarGrelha();
            btCancelar_Click(sender, e);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            btApagar.Visible = false;
            btAtualizar.Visible = false;
            btCancelar.Visible = false;
            btGuardar.Visible = true;
            LimparForm();
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            //validar form
            Equipa equipa = new Equipa();
            equipa.nequipa = nequipa_escolhida;
            equipa.Nome = txtNome.Text;
            equipa.Campeonato = txtCampeonato.Text;
            if (Emblema != null && Emblema!="")
            {
                //verificar se existe
                equipa.Emblema = Utils.ImagemParaVetor(Emblema);
            }
            equipa.Atualizar(bd);
            btCancelar_Click(sender, e);
            AtualizarGrelha();
        }

        private void dgvEquipas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvEquipas.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int nequipa = int.Parse(dgvEquipas.Rows[linha].Cells[0].Value.ToString());
            Equipa escolhido = new Equipa();
            escolhido.Procurar(nequipa, bd);
            txtNome.Text = escolhido.Nome;
            txtCampeonato.Text = escolhido.Campeonato;
            string ficheiro = System.IO.Path.GetTempPath() + @"\imagem.jpg";
            Utils.VetorParaImagem(escolhido.Emblema, ficheiro);
            Image img;
            using (var bitmap = new Bitmap(ficheiro))
            {
                img = new Bitmap(bitmap);
                pbemblema.Image = img;
            }

            //Guardar 
            nequipa_escolhida = nequipa;

            //Atualizar botoes
            btGuardar.Visible = false;
            btEscolher.Visible = true;
            btAtualizar.Visible = true;
            btCancelar.Visible = true;
            btApagar.Visible = true;
        }

        private void TxtPesquisa_TextChanged(object sender, EventArgs e)
        {
            dgvEquipas.DataSource = Equipa.Pesquisa(bd, TxtPesquisa.Text);
        }
    }

}

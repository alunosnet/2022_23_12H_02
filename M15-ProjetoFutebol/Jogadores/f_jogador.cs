using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M15_ProjetoFutebol.Jogadores
{
    public partial class f_jogador : Form
    {
        int NrRegistosPorPagina = 5;
        BaseDados bd;
        int njogador_escolhido;
        string fotografia;
        int nrlinhas, nrpagina;

        public f_jogador(BaseDados bd)
        {
            this.bd=bd;
            InitializeComponent();
            AtualizarGrelha();
            AtualizaNrPaginas();
        }

        /// <summary>
        /// Selecionar Fotografia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEscolher_Click(object sender, EventArgs e)
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
                    pbfotografia.Image = Image.FromFile(temp);
                    fotografia = temp;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fotografia))
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
            if (txtIdade.Text == "" || int.Parse(txtIdade.Text)<18)
            {
                MessageBox.Show("Idade tem de ser maior que 18.");
                txtIdade.Focus();
                return;
            }

            //criar jogador
            Jogador jogador = new Jogador(0, txtNome.Text, int.Parse(txtIdade.Text), Utils.ImagemParaVetor(fotografia), false);

            //Guardar na base de dados
            jogador.Guardar(bd);

            //limpar form
            LimparForm();

            //atualizar grid
            AtualizaNrPaginas();
            AtualizarGrelha();

        }

        private void AtualizarGrelha()
        {
            dgvJogadores.AllowUserToAddRows = false;
            dgvJogadores.AllowUserToDeleteRows = false;
            dgvJogadores.ReadOnly = true;
            //dgvJogadores.DataSource = Jogador.ListarTodos(bd);

            if (cmbPaginas.SelectedIndex == -1)
                dgvJogadores.DataSource = Jogador.ListarTodos(bd);
            else
            {
                //Paginação
                int nrpagina = cmbPaginas.SelectedIndex + 1;
                int primeiroregisto = (nrpagina - 1) * NrRegistosPorPagina + 1;
                int ultimoregisto = primeiroregisto + NrRegistosPorPagina - 1;
                dgvJogadores.DataSource = Jogador.ListarTodos(bd, primeiroregisto, ultimoregisto);
            }
        }

        private void LimparForm()
        {
            txtNome.Text = "";
            txtIdade.Text = "";
            pbfotografia.Image = null;
            fotografia = "";

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            Jogador jog = new Jogador();
            jog.Procurar(njogador_escolhido, bd);
            if(jog.Estado == true)
            {
                MessageBox.Show("Este jogador não pode ser apagado pois tem um contrato ativo!");
            }
            else
            {
                Jogador.Apagar(bd, njogador_escolhido);
                AtualizarGrelha();
                AtualizaNrPaginas();
                btnCancelar_Click(sender, e);
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnApagar.Visible = false;
            btnAtualizar.Visible = false;
            btnCancelar.Visible = false;
            btnGuardar.Visible = true;
            LimparForm();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            //validar form
            Jogador jogador = new Jogador();
            jogador.njogador = njogador_escolhido;
            jogador.Nome = txtNome.Text;
            jogador.Idade = int.Parse(txtIdade.Text);
            if (fotografia != null && fotografia!="")
            {
                //verificar se existe
                jogador.Fotografia = Utils.ImagemParaVetor(fotografia);
            }
            jogador.Atualizar(bd);
            btnCancelar_Click(sender, e);
            AtualizarGrelha();

        }

        private void dgvJogadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int linha = dgvJogadores.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int njogador = int.Parse(dgvJogadores.Rows[linha].Cells[0].Value.ToString());
            Jogador escolhido = new Jogador();
            escolhido.Procurar(njogador, bd);
            txtNome.Text = escolhido.Nome;
            txtIdade.Text = escolhido.Idade.ToString();
            string ficheiro = System.IO.Path.GetTempPath() + @"\imagem.jpg";
            Utils.VetorParaImagem(escolhido.Fotografia, ficheiro);
            Image img;
            using (var bitmap = new Bitmap(ficheiro))
            {
                img = new Bitmap(bitmap);
                pbfotografia.Image = img;
            }

            //Guardar 
            njogador_escolhido = njogador;

            //Atualizar botoes
            btnGuardar.Visible = false;
            btnEscolher.Visible = true;
            btnAtualizar.Visible = true;
            btnCancelar.Visible = true;
            btnApagar.Visible = true;

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            dgvJogadores.DataSource = Jogador.Pesquisa(bd, txtPesquisa.Text);
        }

        private void cmbPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarGrelha();
        }

        void AtualizaNrPaginas()
        {
            cmbPaginas.Items.Clear();
            int nrJogadores = Jogador.NrRegistos(bd);
            int nrPaginas = (int)Math.Ceiling(nrJogadores / (float)NrRegistosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                cmbPaginas.Items.Add(i);
            /*para o caso de não existirem livros*/
            if (cmbPaginas.Items.Count == 0)
                cmbPaginas.Items.Add(1);
            cmbPaginas.SelectedIndex = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }


        private void imprimeGrelha(System.Drawing.Printing.PrintPageEventArgs e, DataGridView grelha)
        {
            Graphics impressora = e.Graphics;
            Font tipoLetra = new Font("Arial", 10);
            Font tipoLetraMaior = new Font("Arial", 12, FontStyle.Bold);
            Brush cor = Brushes.Black;
            float mesquerda, mdireita, msuperior, minferior, linha, largura;
            Pen caneta = new Pen(cor, 2);

            //margens
            mesquerda = printDocument1.DefaultPageSettings.Margins.Left;
            mdireita = printDocument1.DefaultPageSettings.Bounds.Right - mesquerda;
            msuperior = printDocument1.DefaultPageSettings.Margins.Top;
            minferior = printDocument1.DefaultPageSettings.Bounds.Height - msuperior;
            largura = mdireita - mesquerda;
            //calcular as colunas da grelha
            float[] colunas = new float[grelha.Columns.Count];
            float lgrelha = 0;
            for (int i = 0; i < grelha.Columns.Count; i++)
                lgrelha += grelha.Columns[i].Width;
            colunas[0] = mesquerda;
            float total = mesquerda, larguraColuna;
            for (int i = 0; i < grelha.Columns.Count - 1; i++)
            {
                larguraColuna = grelha.Columns[i].Width / lgrelha;
                colunas[i + 1] = larguraColuna * largura + total;
                total = colunas[i + 1];
            }
            //cabeçalhos
            for (int i = 0; i < grelha.Columns.Count; i++)
            {
                impressora.DrawString(grelha.Columns[i].HeaderText, tipoLetraMaior, cor, colunas[i], msuperior);
            }
            linha = msuperior + tipoLetraMaior.Height;
            //ciclo para percorrer a grelha
            int l;
            for (l = nrlinhas; l < grelha.Rows.Count; l++)
            {
                //desenhar linha
                impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
                //escrever uma linha
                for (int c = 0; c < grelha.Columns.Count; c++)
                {
                    impressora.DrawString(grelha.Rows[l].Cells[c].Value.ToString(),
                        tipoLetra, cor, colunas[c], linha);
                }
                //avançar para linha seguinte
                linha = linha + tipoLetra.Height;
                //verificar se o papel acabou
                if (linha + tipoLetra.Height > minferior)
                    break;
            }
            //tem mais páginas?
            if (l < grelha.Rows.Count)
            {
                nrlinhas = l + 1;
                e.HasMorePages = true;
            }
            //rodapé
            impressora.DrawString("12ºH - Página " + nrpagina.ToString(), tipoLetra, cor, mesquerda, minferior);
            //nr página
            nrpagina++;
            //linhas
            //linha superior
            impressora.DrawLine(caneta, mesquerda, msuperior, mdireita, msuperior);
            //linha inferior
            impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
            //colunas
            for (int c = 0; c < colunas.Length; c++)
            {
                impressora.DrawLine(caneta, colunas[c], msuperior, colunas[c], linha);
            }
            //linha lado direito
            impressora.DrawLine(caneta, mdireita, msuperior, mdireita, linha);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            imprimeGrelha(e, dgvJogadores);
        }

    }
}

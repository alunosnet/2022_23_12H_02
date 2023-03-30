using M15_ProjetoFutebol.Equipas;
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
using static System.Windows.Forms.LinkLabel;

namespace M15_ProjetoFutebol.Contratos
{
    public partial class f_contrato : Form
    {
        BaseDados bd;
        int njogador_escolhido;
        int ncontrato_escolhido;

        public f_contrato(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            Contrato cont = new Contrato();
            cont.FimContrato(bd);
            AtualizaJogadores();
            AtualizaEquipas();
            AtualizarGrelha();
        }

        void AtualizarGrelha()
        {
            dgvContratos.AllowUserToAddRows = false;
            dgvContratos.AllowUserToDeleteRows = false;
            dgvContratos.ReadOnly = true;
            dgvContratos.DataSource = Contrato.ListarContratados(bd);
        }

        private void AtualizaJogadores()
        {
            cbJogador.Items.Clear();
            DataTable dados = Jogador.ListarDisponiveis(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Jogador jogador = new Jogador();
                jogador.njogador = int.Parse(dr["njogador"].ToString());
                jogador.Nome = dr["nome"].ToString();
                cbJogador.Items.Add(jogador);
            }
            
        }

        private void AtualizaEquipas()
        {
            cbEquipa.Items.Clear();
            DataTable dados = Equipa.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Equipa equipa = new Equipa();
                equipa.nequipa = int.Parse(dr["nequipa"].ToString());
                equipa.Nome = dr["nome"].ToString();
                cbEquipa.Items.Add(equipa);
            }
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {
            if (cbJogador.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um Jogador!");
                return;
            }
            if (cbEquipa.SelectedIndex==-1)
            {
                MessageBox.Show("Escolha uma Equipa!");
                return;
            }
            if (dtpIncio.Value > dtpFim.Value)
            {
                MessageBox.Show("Datas inválidas.");
                return;
            }
            if (dtpFim.Value <= DateTime.Now)
            {
                MessageBox.Show("Datas inválidas.");
                return;
            }

            Jogador jogador = cbJogador.SelectedItem as Jogador;
            Equipa equipa = cbEquipa.SelectedItem as Equipa;
            Contrato contrato = new Contrato(jogador.njogador, equipa.nequipa, dtpIncio.Value, dtpFim.Value);
            contrato.Contratar(bd);
            LimparForm();
            AtualizaJogadores();
            AtualizarGrelha();
            
        }

        public void LimparForm()
        {
            cbEquipa.Text="";
            cbJogador.Text="";
            dtpIncio.Value = DateTime.Now;
            dtpFim.Value = DateTime.Now;
        }

        private void btnAcabar_Click(object sender, EventArgs e)
        {
            Contrato.Apagar(bd, ncontrato_escolhido);
            Contrato.UpdateJogador(bd, njogador_escolhido);
            AtualizarGrelha();
            LimparForm();
        }

        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvContratos.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int ncontrato = int.Parse(dgvContratos.Rows[linha].Cells[0].Value.ToString());
            int njogador = int.Parse(dgvContratos.Rows[linha].Cells[1].Value.ToString());
            Contrato escolhido = new Contrato();
            escolhido.Procurar(ncontrato, bd);
            cbEquipa.Text = escolhido.nequipa.ToString();
            cbJogador.Text = escolhido.njogador.ToString();

            njogador_escolhido = njogador;
            ncontrato_escolhido = ncontrato;
            


        }
       
    }
}

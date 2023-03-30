using M15_ProjetoFutebol.Contratos;
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

namespace M15_ProjetoFutebol
{
    
    public partial class Menu : Form
    {
        BaseDados bd;

        public Menu(BaseDados bd)
        {
            this.bd = bd;   
            InitializeComponent();
        }

        private void btnJogadores_Click(object sender, EventArgs e)
        {
            f_jogador jogador = new f_jogador(bd);
            jogador.Show();
        }

        private void btnEquipas_Click(object sender, EventArgs e)
        {
            f_equipas equipas = new f_equipas(bd);
            equipas.Show();
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            f_contrato contrato = new f_contrato(bd);
            contrato.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }

}

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
    public partial class Iniciar : Form
    {
        BaseDados bd = new BaseDados("PROJETO");
        public Iniciar()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(bd);
            menu.Show();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_consulta consulta = new f_consulta(bd);
            consulta.Show();
        }
    }
}

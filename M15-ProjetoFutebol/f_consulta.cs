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
    public partial class f_consulta : Form
    {
        BaseDados bd;
        public f_consulta(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
        }

        private void PrimeiraConsulta_Click(object sender, EventArgs e)
        {
            Consultas consulta = new Consultas();
            dgvConsultas.DataSource = consulta.primeiraConsulta(bd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consultas consulta = new Consultas();
            dgvConsultas.DataSource = consulta.segundaConsulta(bd);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Consultas consulta = new Consultas();
            dgvConsultas.DataSource = consulta.terceiraConsulta(bd);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Consultas consulta = new Consultas();
            dgvConsultas.DataSource = consulta.quartaConsulta(bd);
        }
    }
}

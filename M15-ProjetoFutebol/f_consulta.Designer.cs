namespace M15_ProjetoFutebol
{
    partial class f_consulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PrimeiraConsulta = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // PrimeiraConsulta
            // 
            this.PrimeiraConsulta.Location = new System.Drawing.Point(12, 34);
            this.PrimeiraConsulta.Name = "PrimeiraConsulta";
            this.PrimeiraConsulta.Size = new System.Drawing.Size(150, 67);
            this.PrimeiraConsulta.TabIndex = 0;
            this.PrimeiraConsulta.Text = "Nº de contratos por equipa";
            this.PrimeiraConsulta.UseVisualStyleBackColor = true;
            this.PrimeiraConsulta.Click += new System.EventHandler(this.PrimeiraConsulta_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 67);
            this.button2.TabIndex = 1;
            this.button2.Text = "Idade dos jogadores daqui a 10 anos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 205);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 67);
            this.button3.TabIndex = 2;
            this.button3.Text = "Jogadores com contratos ativos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 293);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 67);
            this.button4.TabIndex = 3;
            this.button4.Text = "Primeiro nome de todos os jogadores";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.AllowUserToAddRows = false;
            this.dgvConsultas.AllowUserToDeleteRows = false;
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Location = new System.Drawing.Point(168, 34);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.ReadOnly = true;
            this.dgvConsultas.Size = new System.Drawing.Size(594, 326);
            this.dgvConsultas.TabIndex = 4;
            // 
            // f_consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(774, 376);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PrimeiraConsulta);
            this.Name = "f_consulta";
            this.Text = "Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrimeiraConsulta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvConsultas;
    }
}
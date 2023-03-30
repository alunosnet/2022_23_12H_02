namespace M15_ProjetoFutebol
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be 
        /// 
        /// d; otherwise, false.</param>
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
            this.btnJogadores = new System.Windows.Forms.Button();
            this.btnEquipas = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJogadores
            // 
            this.btnJogadores.Location = new System.Drawing.Point(161, 83);
            this.btnJogadores.Name = "btnJogadores";
            this.btnJogadores.Size = new System.Drawing.Size(297, 59);
            this.btnJogadores.TabIndex = 0;
            this.btnJogadores.Text = "Jogadores";
            this.btnJogadores.UseVisualStyleBackColor = true;
            this.btnJogadores.Click += new System.EventHandler(this.btnJogadores_Click);
            // 
            // btnEquipas
            // 
            this.btnEquipas.Location = new System.Drawing.Point(161, 148);
            this.btnEquipas.Name = "btnEquipas";
            this.btnEquipas.Size = new System.Drawing.Size(297, 59);
            this.btnEquipas.TabIndex = 1;
            this.btnEquipas.Text = "Equipas";
            this.btnEquipas.UseVisualStyleBackColor = true;
            this.btnEquipas.Click += new System.EventHandler(this.btnEquipas_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.Location = new System.Drawing.Point(161, 213);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(297, 59);
            this.btnContratos.TabIndex = 3;
            this.btnContratos.Text = "Contratos";
            this.btnContratos.UseVisualStyleBackColor = true;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(620, 369);
            this.Controls.Add(this.btnContratos);
            this.Controls.Add(this.btnEquipas);
            this.Controls.Add(this.btnJogadores);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJogadores;
        private System.Windows.Forms.Button btnEquipas;
        private System.Windows.Forms.Button btnContratos;
    }
}


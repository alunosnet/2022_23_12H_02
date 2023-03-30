namespace M15_ProjetoFutebol.Equipas
{
    partial class f_equipas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btEscolher = new System.Windows.Forms.Button();
            this.pbemblema = new System.Windows.Forms.PictureBox();
            this.btGuardar = new System.Windows.Forms.Button();
            this.btAtualizar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btApagar = new System.Windows.Forms.Button();
            this.dgvEquipas = new System.Windows.Forms.DataGridView();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCampeonato = new System.Windows.Forms.TextBox();
            this.TxtPesquisa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbemblema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Campeonato";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Emblema";
            // 
            // btEscolher
            // 
            this.btEscolher.Location = new System.Drawing.Point(94, 137);
            this.btEscolher.Name = "btEscolher";
            this.btEscolher.Size = new System.Drawing.Size(75, 23);
            this.btEscolher.TabIndex = 6;
            this.btEscolher.Text = "Escolher";
            this.btEscolher.UseVisualStyleBackColor = true;
            this.btEscolher.Click += new System.EventHandler(this.btEscolher_Click);
            // 
            // pbemblema
            // 
            this.pbemblema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbemblema.Location = new System.Drawing.Point(94, 175);
            this.pbemblema.Name = "pbemblema";
            this.pbemblema.Size = new System.Drawing.Size(186, 145);
            this.pbemblema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbemblema.TabIndex = 7;
            this.pbemblema.TabStop = false;
            // 
            // btGuardar
            // 
            this.btGuardar.Location = new System.Drawing.Point(94, 379);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(116, 46);
            this.btGuardar.TabIndex = 8;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // btAtualizar
            // 
            this.btAtualizar.Location = new System.Drawing.Point(371, 379);
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(116, 46);
            this.btAtualizar.TabIndex = 9;
            this.btAtualizar.Text = "Atualizar";
            this.btAtualizar.UseVisualStyleBackColor = true;
            this.btAtualizar.Click += new System.EventHandler(this.btAtualizar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(615, 379);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(116, 46);
            this.btCancelar.TabIndex = 11;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btApagar
            // 
            this.btApagar.Location = new System.Drawing.Point(493, 379);
            this.btApagar.Name = "btApagar";
            this.btApagar.Size = new System.Drawing.Size(116, 46);
            this.btApagar.TabIndex = 12;
            this.btApagar.Text = "Apagar";
            this.btApagar.UseVisualStyleBackColor = true;
            this.btApagar.Click += new System.EventHandler(this.btApagar_Click);
            // 
            // dgvEquipas
            // 
            this.dgvEquipas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipas.Location = new System.Drawing.Point(319, 92);
            this.dgvEquipas.Name = "dgvEquipas";
            this.dgvEquipas.Size = new System.Drawing.Size(408, 262);
            this.dgvEquipas.TabIndex = 13;
            this.dgvEquipas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipas_CellClick);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(95, 50);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(185, 20);
            this.txtNome.TabIndex = 14;
            // 
            // txtCampeonato
            // 
            this.txtCampeonato.Location = new System.Drawing.Point(95, 92);
            this.txtCampeonato.Name = "txtCampeonato";
            this.txtCampeonato.Size = new System.Drawing.Size(185, 20);
            this.txtCampeonato.TabIndex = 15;
            // 
            // TxtPesquisa
            // 
            this.TxtPesquisa.Location = new System.Drawing.Point(319, 50);
            this.TxtPesquisa.Name = "TxtPesquisa";
            this.TxtPesquisa.Size = new System.Drawing.Size(408, 20);
            this.TxtPesquisa.TabIndex = 16;
            this.TxtPesquisa.TextChanged += new System.EventHandler(this.TxtPesquisa_TextChanged);
            // 
            // f_equipas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(743, 443);
            this.Controls.Add(this.TxtPesquisa);
            this.Controls.Add(this.txtCampeonato);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.dgvEquipas);
            this.Controls.Add(this.btApagar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAtualizar);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.pbemblema);
            this.Controls.Add(this.btEscolher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "f_equipas";
            this.Text = "f_equipas";
            ((System.ComponentModel.ISupportInitialize)(this.pbemblema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btEscolher;
        private System.Windows.Forms.PictureBox pbemblema;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Button btAtualizar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btApagar;
        private System.Windows.Forms.DataGridView dgvEquipas;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCampeonato;
        private System.Windows.Forms.TextBox TxtPesquisa;
    }
}
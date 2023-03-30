namespace M15_ProjetoFutebol.Contratos
{
    partial class f_contrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_contrato));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbJogador = new System.Windows.Forms.ComboBox();
            this.cbEquipa = new System.Windows.Forms.ComboBox();
            this.dtpIncio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.btnContratar = new System.Windows.Forms.Button();
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.btnAcabar = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jogador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Equipa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Inicio de Contrato";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fim de Contrato";
            // 
            // cbJogador
            // 
            this.cbJogador.FormattingEnabled = true;
            this.cbJogador.Location = new System.Drawing.Point(174, 62);
            this.cbJogador.Name = "cbJogador";
            this.cbJogador.Size = new System.Drawing.Size(200, 21);
            this.cbJogador.TabIndex = 4;
            // 
            // cbEquipa
            // 
            this.cbEquipa.FormattingEnabled = true;
            this.cbEquipa.Location = new System.Drawing.Point(174, 106);
            this.cbEquipa.Name = "cbEquipa";
            this.cbEquipa.Size = new System.Drawing.Size(200, 21);
            this.cbEquipa.TabIndex = 5;
            // 
            // dtpIncio
            // 
            this.dtpIncio.Location = new System.Drawing.Point(174, 151);
            this.dtpIncio.Name = "dtpIncio";
            this.dtpIncio.Size = new System.Drawing.Size(200, 20);
            this.dtpIncio.TabIndex = 6;
            // 
            // dtpFim
            // 
            this.dtpFim.Location = new System.Drawing.Point(174, 198);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(200, 20);
            this.dtpFim.TabIndex = 7;
            // 
            // btnContratar
            // 
            this.btnContratar.Location = new System.Drawing.Point(174, 294);
            this.btnContratar.Name = "btnContratar";
            this.btnContratar.Size = new System.Drawing.Size(200, 56);
            this.btnContratar.TabIndex = 8;
            this.btnContratar.Text = "Contratar";
            this.btnContratar.UseVisualStyleBackColor = true;
            this.btnContratar.Click += new System.EventHandler(this.btnContratar_Click);
            // 
            // dgvContratos
            // 
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.Location = new System.Drawing.Point(411, 61);
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.Size = new System.Drawing.Size(360, 289);
            this.dgvContratos.TabIndex = 9;
            this.dgvContratos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContratos_CellClick);
            // 
            // btnAcabar
            // 
            this.btnAcabar.Location = new System.Drawing.Point(651, 32);
            this.btnAcabar.Name = "btnAcabar";
            this.btnAcabar.Size = new System.Drawing.Size(119, 23);
            this.btnAcabar.TabIndex = 10;
            this.btnAcabar.Text = "Acabar Contrato";
            this.btnAcabar.UseVisualStyleBackColor = true;
            this.btnAcabar.Click += new System.EventHandler(this.btnAcabar_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // f_contrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(791, 359);
            this.Controls.Add(this.btnAcabar);
            this.Controls.Add(this.dgvContratos);
            this.Controls.Add(this.btnContratar);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.dtpIncio);
            this.Controls.Add(this.cbEquipa);
            this.Controls.Add(this.cbJogador);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "f_contrato";
            this.Text = "f_contrato";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbJogador;
        private System.Windows.Forms.ComboBox cbEquipa;
        private System.Windows.Forms.DateTimePicker dtpIncio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Button btnContratar;
        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.Button btnAcabar;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}
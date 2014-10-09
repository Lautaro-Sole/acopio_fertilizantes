namespace Vista
{
    partial class frmCargaDescarga
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPesoInicial = new System.Windows.Forms.Label();
            this.lblPesoFinal = new System.Windows.Forms.Label();
            this.lblNotas = new System.Windows.Forms.Label();
            this.msktbPesoInicial = new System.Windows.Forms.MaskedTextBox();
            this.msktbPesoFinal = new System.Windows.Forms.MaskedTextBox();
            this.tbNotas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(15, 136);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(284, 136);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPesoInicial
            // 
            this.lblPesoInicial.AutoSize = true;
            this.lblPesoInicial.Location = new System.Drawing.Point(12, 15);
            this.lblPesoInicial.Name = "lblPesoInicial";
            this.lblPesoInicial.Size = new System.Drawing.Size(64, 13);
            this.lblPesoInicial.TabIndex = 1;
            this.lblPesoInicial.Text = "Peso Inicial:";
            // 
            // lblPesoFinal
            // 
            this.lblPesoFinal.AutoSize = true;
            this.lblPesoFinal.Location = new System.Drawing.Point(12, 41);
            this.lblPesoFinal.Name = "lblPesoFinal";
            this.lblPesoFinal.Size = new System.Drawing.Size(59, 13);
            this.lblPesoFinal.TabIndex = 1;
            this.lblPesoFinal.Text = "Peso Final:";
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Location = new System.Drawing.Point(12, 93);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(38, 13);
            this.lblNotas.TabIndex = 1;
            this.lblNotas.Text = "Notas:";
            // 
            // msktbPesoInicial
            // 
            this.msktbPesoInicial.Location = new System.Drawing.Point(109, 12);
            this.msktbPesoInicial.Mask = "99999";
            this.msktbPesoInicial.Name = "msktbPesoInicial";
            this.msktbPesoInicial.Size = new System.Drawing.Size(100, 20);
            this.msktbPesoInicial.TabIndex = 2;
            this.msktbPesoInicial.ValidatingType = typeof(int);
            // 
            // msktbPesoFinal
            // 
            this.msktbPesoFinal.Location = new System.Drawing.Point(109, 38);
            this.msktbPesoFinal.Mask = "99999";
            this.msktbPesoFinal.Name = "msktbPesoFinal";
            this.msktbPesoFinal.Size = new System.Drawing.Size(100, 20);
            this.msktbPesoFinal.TabIndex = 2;
            this.msktbPesoFinal.ValidatingType = typeof(int);
            // 
            // tbNotas
            // 
            this.tbNotas.Location = new System.Drawing.Point(109, 90);
            this.tbNotas.MaxLength = 320;
            this.tbNotas.Name = "tbNotas";
            this.tbNotas.Size = new System.Drawing.Size(250, 20);
            this.tbNotas.TabIndex = 3;
            // 
            // frmCargaDescarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 177);
            this.Controls.Add(this.tbNotas);
            this.Controls.Add(this.msktbPesoFinal);
            this.Controls.Add(this.msktbPesoInicial);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.lblPesoFinal);
            this.Controls.Add(this.lblPesoInicial);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "frmCargaDescarga";
            this.Text = "Registrar Carga";
            this.Load += new System.EventHandler(this.frmCargaDescarga_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblPesoInicial;
        private System.Windows.Forms.Label lblPesoFinal;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.MaskedTextBox msktbPesoInicial;
        private System.Windows.Forms.MaskedTextBox msktbPesoFinal;
        private System.Windows.Forms.TextBox tbNotas;
    }
}
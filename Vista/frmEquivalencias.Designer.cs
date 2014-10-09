namespace Vista
{
    partial class frmEquivalencias
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
            this.lblKilogramos = new System.Windows.Forms.Label();
            this.lblBolsas = new System.Windows.Forms.Label();
            this.lblMetrosCuadrados = new System.Windows.Forms.Label();
            this.msktbBolsas = new System.Windows.Forms.MaskedTextBox();
            this.msktbKilogramos = new System.Windows.Forms.MaskedTextBox();
            this.msktbMetrosCuadrados = new System.Windows.Forms.MaskedTextBox();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblKilogramos
            // 
            this.lblKilogramos.AutoSize = true;
            this.lblKilogramos.Location = new System.Drawing.Point(25, 15);
            this.lblKilogramos.Name = "lblKilogramos";
            this.lblKilogramos.Size = new System.Drawing.Size(61, 13);
            this.lblKilogramos.TabIndex = 0;
            this.lblKilogramos.Text = "Kilogramos:";
            this.lblKilogramos.Click += new System.EventHandler(this.lblKilogramos_Click);
            // 
            // lblBolsas
            // 
            this.lblBolsas.AutoSize = true;
            this.lblBolsas.Location = new System.Drawing.Point(25, 41);
            this.lblBolsas.Name = "lblBolsas";
            this.lblBolsas.Size = new System.Drawing.Size(41, 13);
            this.lblBolsas.TabIndex = 0;
            this.lblBolsas.Text = "Bolsas:";
            this.lblBolsas.Click += new System.EventHandler(this.lblKilogramos_Click);
            // 
            // lblMetrosCuadrados
            // 
            this.lblMetrosCuadrados.AutoSize = true;
            this.lblMetrosCuadrados.Location = new System.Drawing.Point(25, 67);
            this.lblMetrosCuadrados.Name = "lblMetrosCuadrados";
            this.lblMetrosCuadrados.Size = new System.Drawing.Size(96, 13);
            this.lblMetrosCuadrados.TabIndex = 0;
            this.lblMetrosCuadrados.Text = "Metros Cuadrados:";
            this.lblMetrosCuadrados.Click += new System.EventHandler(this.lblKilogramos_Click);
            // 
            // msktbBolsas
            // 
            this.msktbBolsas.Location = new System.Drawing.Point(135, 38);
            this.msktbBolsas.Mask = "99999";
            this.msktbBolsas.Name = "msktbBolsas";
            this.msktbBolsas.Size = new System.Drawing.Size(100, 20);
            this.msktbBolsas.TabIndex = 1;
            this.msktbBolsas.ValidatingType = typeof(int);
            // 
            // msktbKilogramos
            // 
            this.msktbKilogramos.Location = new System.Drawing.Point(135, 12);
            this.msktbKilogramos.Mask = "99999";
            this.msktbKilogramos.Name = "msktbKilogramos";
            this.msktbKilogramos.Size = new System.Drawing.Size(100, 20);
            this.msktbKilogramos.TabIndex = 1;
            this.msktbKilogramos.ValidatingType = typeof(int);
            // 
            // msktbMetrosCuadrados
            // 
            this.msktbMetrosCuadrados.Location = new System.Drawing.Point(135, 64);
            this.msktbMetrosCuadrados.Mask = "99999";
            this.msktbMetrosCuadrados.Name = "msktbMetrosCuadrados";
            this.msktbMetrosCuadrados.Size = new System.Drawing.Size(100, 20);
            this.msktbMetrosCuadrados.TabIndex = 1;
            this.msktbMetrosCuadrados.ValidatingType = typeof(int);
            // 
            // btnConvertir
            // 
            this.btnConvertir.Location = new System.Drawing.Point(28, 165);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(75, 23);
            this.btnConvertir.TabIndex = 2;
            this.btnConvertir.Text = "Convertir";
            this.btnConvertir.UseVisualStyleBackColor = true;
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(160, 165);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmEquivalencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 214);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.msktbKilogramos);
            this.Controls.Add(this.msktbMetrosCuadrados);
            this.Controls.Add(this.msktbBolsas);
            this.Controls.Add(this.lblMetrosCuadrados);
            this.Controls.Add(this.lblBolsas);
            this.Controls.Add(this.lblKilogramos);
            this.Name = "frmEquivalencias";
            this.Text = "Equivalencias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKilogramos;
        private System.Windows.Forms.Label lblBolsas;
        private System.Windows.Forms.Label lblMetrosCuadrados;
        private System.Windows.Forms.MaskedTextBox msktbBolsas;
        private System.Windows.Forms.MaskedTextBox msktbKilogramos;
        private System.Windows.Forms.MaskedTextBox msktbMetrosCuadrados;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.Button btnCerrar;
    }
}
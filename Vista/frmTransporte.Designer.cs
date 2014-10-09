namespace Vista
{
    partial class frmTransporte
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbNumMatricula = new System.Windows.Forms.TextBox();
            this.lblNumMatricula = new System.Windows.Forms.Label();
            this.lblTipoMatricula = new System.Windows.Forms.Label();
            this.cbTipoMatricula = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.msktbTara = new System.Windows.Forms.MaskedTextBox();
            this.msktbCargaMaxima = new System.Windows.Forms.MaskedTextBox();
            this.clbChoferes = new System.Windows.Forms.CheckedListBox();
            this.lblChoferes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(362, 283);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 283);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tbNumMatricula
            // 
            this.tbNumMatricula.Location = new System.Drawing.Point(199, 49);
            this.tbNumMatricula.MaxLength = 60;
            this.tbNumMatricula.Name = "tbNumMatricula";
            this.tbNumMatricula.Size = new System.Drawing.Size(238, 20);
            this.tbNumMatricula.TabIndex = 15;
            // 
            // lblNumMatricula
            // 
            this.lblNumMatricula.AutoSize = true;
            this.lblNumMatricula.Location = new System.Drawing.Point(29, 52);
            this.lblNumMatricula.Name = "lblNumMatricula";
            this.lblNumMatricula.Size = new System.Drawing.Size(110, 13);
            this.lblNumMatricula.TabIndex = 10;
            this.lblNumMatricula.Text = "Número de Matrícula:";
            // 
            // lblTipoMatricula
            // 
            this.lblTipoMatricula.AutoSize = true;
            this.lblTipoMatricula.Location = new System.Drawing.Point(29, 26);
            this.lblTipoMatricula.Name = "lblTipoMatricula";
            this.lblTipoMatricula.Size = new System.Drawing.Size(94, 13);
            this.lblTipoMatricula.TabIndex = 9;
            this.lblTipoMatricula.Text = "Tipo de Matrícula:";
            // 
            // cbTipoMatricula
            // 
            this.cbTipoMatricula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoMatricula.FormattingEnabled = true;
            this.cbTipoMatricula.Items.AddRange(new object[] {
            "Patente"});
            this.cbTipoMatricula.Location = new System.Drawing.Point(199, 22);
            this.cbTipoMatricula.Name = "cbTipoMatricula";
            this.cbTipoMatricula.Size = new System.Drawing.Size(238, 21);
            this.cbTipoMatricula.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tara:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Carga Máxima:";
            // 
            // msktbTara
            // 
            this.msktbTara.Location = new System.Drawing.Point(199, 75);
            this.msktbTara.Mask = "99999";
            this.msktbTara.Name = "msktbTara";
            this.msktbTara.Size = new System.Drawing.Size(238, 20);
            this.msktbTara.TabIndex = 23;
            this.msktbTara.ValidatingType = typeof(int);
            // 
            // msktbCargaMaxima
            // 
            this.msktbCargaMaxima.Location = new System.Drawing.Point(199, 101);
            this.msktbCargaMaxima.Mask = "99999";
            this.msktbCargaMaxima.Name = "msktbCargaMaxima";
            this.msktbCargaMaxima.Size = new System.Drawing.Size(238, 20);
            this.msktbCargaMaxima.TabIndex = 23;
            this.msktbCargaMaxima.ValidatingType = typeof(int);
            // 
            // clbChoferes
            // 
            this.clbChoferes.FormattingEnabled = true;
            this.clbChoferes.Location = new System.Drawing.Point(199, 127);
            this.clbChoferes.Name = "clbChoferes";
            this.clbChoferes.Size = new System.Drawing.Size(238, 139);
            this.clbChoferes.TabIndex = 24;
            // 
            // lblChoferes
            // 
            this.lblChoferes.AutoSize = true;
            this.lblChoferes.Location = new System.Drawing.Point(29, 127);
            this.lblChoferes.Name = "lblChoferes";
            this.lblChoferes.Size = new System.Drawing.Size(164, 13);
            this.lblChoferes.TabIndex = 22;
            this.lblChoferes.Text = "Choferes que pueden conducirlo:";
            // 
            // frmTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 318);
            this.Controls.Add(this.clbChoferes);
            this.Controls.Add(this.msktbCargaMaxima);
            this.Controls.Add(this.msktbTara);
            this.Controls.Add(this.lblChoferes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTipoMatricula);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tbNumMatricula);
            this.Controls.Add(this.lblNumMatricula);
            this.Controls.Add(this.lblTipoMatricula);
            this.Name = "frmTransporte";
            this.Text = "Transporte";
            this.Load += new System.EventHandler(this.frmTransporte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox tbNumMatricula;
        private System.Windows.Forms.Label lblNumMatricula;
        private System.Windows.Forms.Label lblTipoMatricula;
        private System.Windows.Forms.ComboBox cbTipoMatricula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox msktbTara;
        private System.Windows.Forms.MaskedTextBox msktbCargaMaxima;
        private System.Windows.Forms.CheckedListBox clbChoferes;
        private System.Windows.Forms.Label lblChoferes;
    }
}
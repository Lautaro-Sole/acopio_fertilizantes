namespace Vista
{
    partial class frmCClave
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
            this.components = new System.ComponentModel.Container();
            this.lblClaveActual = new System.Windows.Forms.Label();
            this.lblClaveNueva = new System.Windows.Forms.Label();
            this.lblClaveNueva2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tbClaveActual = new System.Windows.Forms.TextBox();
            this.tbClaveNueva = new System.Windows.Forms.TextBox();
            this.tbClaveNueva2 = new System.Windows.Forms.TextBox();
            this.ttClaves = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblClaveActual
            // 
            this.lblClaveActual.AutoSize = true;
            this.lblClaveActual.Location = new System.Drawing.Point(12, 15);
            this.lblClaveActual.Name = "lblClaveActual";
            this.lblClaveActual.Size = new System.Drawing.Size(70, 13);
            this.lblClaveActual.TabIndex = 0;
            this.lblClaveActual.Text = "Clave Actual:";
            // 
            // lblClaveNueva
            // 
            this.lblClaveNueva.AutoSize = true;
            this.lblClaveNueva.Location = new System.Drawing.Point(12, 41);
            this.lblClaveNueva.Name = "lblClaveNueva";
            this.lblClaveNueva.Size = new System.Drawing.Size(72, 13);
            this.lblClaveNueva.TabIndex = 0;
            this.lblClaveNueva.Text = "Clave Nueva:";
            // 
            // lblClaveNueva2
            // 
            this.lblClaveNueva2.AutoSize = true;
            this.lblClaveNueva2.Location = new System.Drawing.Point(12, 67);
            this.lblClaveNueva2.Name = "lblClaveNueva2";
            this.lblClaveNueva2.Size = new System.Drawing.Size(119, 13);
            this.lblClaveNueva2.TabIndex = 0;
            this.lblClaveNueva2.Text = "Confirmar Clave Nueva:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(65, 90);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(201, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tbClaveActual
            // 
            this.tbClaveActual.Location = new System.Drawing.Point(145, 12);
            this.tbClaveActual.MaxLength = 32;
            this.tbClaveActual.Name = "tbClaveActual";
            this.tbClaveActual.PasswordChar = '*';
            this.tbClaveActual.Size = new System.Drawing.Size(200, 20);
            this.tbClaveActual.TabIndex = 2;
            this.ttClaves.SetToolTip(this.tbClaveActual, "Ingrese la clave actual.");
            // 
            // tbClaveNueva
            // 
            this.tbClaveNueva.Location = new System.Drawing.Point(145, 38);
            this.tbClaveNueva.MaxLength = 32;
            this.tbClaveNueva.Name = "tbClaveNueva";
            this.tbClaveNueva.PasswordChar = '*';
            this.tbClaveNueva.Size = new System.Drawing.Size(200, 20);
            this.tbClaveNueva.TabIndex = 2;
            this.ttClaves.SetToolTip(this.tbClaveNueva, "Ingrese una clave nueva de hasta 32 carácteres.");
            // 
            // tbClaveNueva2
            // 
            this.tbClaveNueva2.Location = new System.Drawing.Point(145, 64);
            this.tbClaveNueva2.MaxLength = 32;
            this.tbClaveNueva2.Name = "tbClaveNueva2";
            this.tbClaveNueva2.PasswordChar = '*';
            this.tbClaveNueva2.Size = new System.Drawing.Size(200, 20);
            this.tbClaveNueva2.TabIndex = 2;
            this.ttClaves.SetToolTip(this.tbClaveNueva2, "Repita la clave nueva.");
            // 
            // frmCClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 129);
            this.Controls.Add(this.tbClaveNueva2);
            this.Controls.Add(this.tbClaveNueva);
            this.Controls.Add(this.tbClaveActual);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblClaveNueva2);
            this.Controls.Add(this.lblClaveNueva);
            this.Controls.Add(this.lblClaveActual);
            this.Name = "frmCClave";
            this.Text = "Cambiar Clave";
            this.Load += new System.EventHandler(this.frmCClave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClaveActual;
        private System.Windows.Forms.Label lblClaveNueva;
        private System.Windows.Forms.Label lblClaveNueva2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox tbClaveActual;
        private System.Windows.Forms.ToolTip ttClaves;
        private System.Windows.Forms.TextBox tbClaveNueva;
        private System.Windows.Forms.TextBox tbClaveNueva2;
    }
}
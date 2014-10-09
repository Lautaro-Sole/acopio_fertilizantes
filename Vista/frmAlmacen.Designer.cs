namespace Vista
{
    partial class frmAlmacen
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.lblSupTotal = new System.Windows.Forms.Label();
            this.lblSupNoAlquilada = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.msktbDistancia = new System.Windows.Forms.MaskedTextBox();
            this.msktbCapacidadTotal = new System.Windows.Forms.MaskedTextBox();
            this.msktbCapacidad_no_Alquilada = new System.Windows.Forms.MaskedTextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(43, 41);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(43, 67);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 1;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.Location = new System.Drawing.Point(43, 93);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(118, 13);
            this.lblDistancia.TabIndex = 2;
            this.lblDistancia.Text = "Distancia a la Empresa:";
            // 
            // lblSupTotal
            // 
            this.lblSupTotal.AutoSize = true;
            this.lblSupTotal.Location = new System.Drawing.Point(43, 119);
            this.lblSupTotal.Name = "lblSupTotal";
            this.lblSupTotal.Size = new System.Drawing.Size(88, 13);
            this.lblSupTotal.TabIndex = 3;
            this.lblSupTotal.Text = "Capacidad Total:";
            // 
            // lblSupNoAlquilada
            // 
            this.lblSupNoAlquilada.AutoSize = true;
            this.lblSupNoAlquilada.Location = new System.Drawing.Point(43, 145);
            this.lblSupNoAlquilada.Name = "lblSupNoAlquilada";
            this.lblSupNoAlquilada.Size = new System.Drawing.Size(124, 13);
            this.lblSupNoAlquilada.TabIndex = 4;
            this.lblSupNoAlquilada.Text = "Capacidad No Alquilada:";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(200, 38);
            this.tbNombre.MaxLength = 60;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(177, 20);
            this.tbNombre.TabIndex = 5;
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(200, 64);
            this.tbDireccion.MaxLength = 60;
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(177, 20);
            this.tbDireccion.TabIndex = 5;
            // 
            // msktbDistancia
            // 
            this.msktbDistancia.Location = new System.Drawing.Point(200, 90);
            this.msktbDistancia.Mask = "99999";
            this.msktbDistancia.Name = "msktbDistancia";
            this.msktbDistancia.Size = new System.Drawing.Size(177, 20);
            this.msktbDistancia.TabIndex = 6;
            this.msktbDistancia.ValidatingType = typeof(int);
            // 
            // msktbCapacidadTotal
            // 
            this.msktbCapacidadTotal.Location = new System.Drawing.Point(200, 116);
            this.msktbCapacidadTotal.Mask = "99999";
            this.msktbCapacidadTotal.Name = "msktbCapacidadTotal";
            this.msktbCapacidadTotal.Size = new System.Drawing.Size(177, 20);
            this.msktbCapacidadTotal.TabIndex = 6;
            this.msktbCapacidadTotal.ValidatingType = typeof(int);
            // 
            // msktbCapacidad_no_Alquilada
            // 
            this.msktbCapacidad_no_Alquilada.Enabled = false;
            this.msktbCapacidad_no_Alquilada.Location = new System.Drawing.Point(200, 142);
            this.msktbCapacidad_no_Alquilada.Mask = "99999";
            this.msktbCapacidad_no_Alquilada.Name = "msktbCapacidad_no_Alquilada";
            this.msktbCapacidad_no_Alquilada.Size = new System.Drawing.Size(177, 20);
            this.msktbCapacidad_no_Alquilada.TabIndex = 6;
            this.msktbCapacidad_no_Alquilada.ValidatingType = typeof(int);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(46, 226);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(302, 226);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 286);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.msktbCapacidad_no_Alquilada);
            this.Controls.Add(this.msktbCapacidadTotal);
            this.Controls.Add(this.msktbDistancia);
            this.Controls.Add(this.tbDireccion);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblSupNoAlquilada);
            this.Controls.Add(this.lblSupTotal);
            this.Controls.Add(this.lblDistancia);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmAlmacen";
            this.Text = "Almacén";
            this.Load += new System.EventHandler(this.frmAlmacen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label lblSupTotal;
        private System.Windows.Forms.Label lblSupNoAlquilada;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.MaskedTextBox msktbDistancia;
        private System.Windows.Forms.MaskedTextBox msktbCapacidadTotal;
        private System.Windows.Forms.MaskedTextBox msktbCapacidad_no_Alquilada;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
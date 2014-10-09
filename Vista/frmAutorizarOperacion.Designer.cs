namespace Vista
{
    partial class frmAutorizarOperacion
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
            this.tbNotas = new System.Windows.Forms.TextBox();
            this.lblNotas = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.dgvAlquileres = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.msktbSupNoUtilizadaMinima = new System.Windows.Forms.MaskedTextBox();
            this.lblSuperficieNoUtilizada = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.msktbDistMaxAEmpresa = new System.Windows.Forms.MaskedTextBox();
            this.tbNombreCliente = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.tcAutorizacion = new System.Windows.Forms.TabControl();
            this.tpAlquiler = new System.Windows.Forms.TabPage();
            this.tpDocumento = new System.Windows.Forms.TabPage();
            this.dtpFechaYHora = new System.Windows.Forms.DateTimePicker();
            this.cbTipoFertilizante = new System.Windows.Forms.ComboBox();
            this.msktbCantidad = new System.Windows.Forms.MaskedTextBox();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.lblTipoFertilizante = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblNro_Documento = new System.Windows.Forms.Label();
            this.msktbNro_Documento = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tcAutorizacion.SuspendLayout();
            this.tpAlquiler.SuspendLayout();
            this.tpDocumento.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNotas
            // 
            this.tbNotas.Location = new System.Drawing.Point(53, 635);
            this.tbNotas.MaxLength = 320;
            this.tbNotas.Name = "tbNotas";
            this.tbNotas.Size = new System.Drawing.Size(943, 20);
            this.tbNotas.TabIndex = 23;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Location = new System.Drawing.Point(9, 638);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(38, 13);
            this.lblNotas.TabIndex = 22;
            this.lblNotas.Text = "Notas:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(921, 661);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Location = new System.Drawing.Point(12, 661);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(75, 23);
            this.btnAutorizar.TabIndex = 20;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.UseVisualStyleBackColor = true;
            this.btnAutorizar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvAlquileres
            // 
            this.dgvAlquileres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlquileres.Location = new System.Drawing.Point(6, 112);
            this.dgvAlquileres.Name = "dgvAlquileres";
            this.dgvAlquileres.Size = new System.Drawing.Size(964, 465);
            this.dgvAlquileres.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.msktbSupNoUtilizadaMinima);
            this.groupBox1.Controls.Add(this.lblSuperficieNoUtilizada);
            this.groupBox1.Controls.Add(this.lblDistancia);
            this.groupBox1.Controls.Add(this.lblNombreCliente);
            this.groupBox1.Controls.Add(this.msktbDistMaxAEmpresa);
            this.groupBox1.Controls.Add(this.tbNombreCliente);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // msktbSupNoUtilizadaMinima
            // 
            this.msktbSupNoUtilizadaMinima.Location = new System.Drawing.Point(224, 45);
            this.msktbSupNoUtilizadaMinima.Mask = "99999";
            this.msktbSupNoUtilizadaMinima.Name = "msktbSupNoUtilizadaMinima";
            this.msktbSupNoUtilizadaMinima.Size = new System.Drawing.Size(179, 20);
            this.msktbSupNoUtilizadaMinima.TabIndex = 10;
            // 
            // lblSuperficieNoUtilizada
            // 
            this.lblSuperficieNoUtilizada.AutoSize = true;
            this.lblSuperficieNoUtilizada.Location = new System.Drawing.Point(6, 48);
            this.lblSuperficieNoUtilizada.Name = "lblSuperficieNoUtilizada";
            this.lblSuperficieNoUtilizada.Size = new System.Drawing.Size(125, 13);
            this.lblSuperficieNoUtilizada.TabIndex = 13;
            this.lblSuperficieNoUtilizada.Text = "Capacidad Libre Mínima:";
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.Location = new System.Drawing.Point(6, 74);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(156, 13);
            this.lblDistancia.TabIndex = 12;
            this.lblDistancia.Text = "Distancia Máxima a la empresa:";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(6, 22);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(99, 13);
            this.lblNombreCliente.TabIndex = 11;
            this.lblNombreCliente.Text = "Nombre del Cliente:";
            // 
            // msktbDistMaxAEmpresa
            // 
            this.msktbDistMaxAEmpresa.Location = new System.Drawing.Point(224, 71);
            this.msktbDistMaxAEmpresa.Mask = "99999";
            this.msktbDistMaxAEmpresa.Name = "msktbDistMaxAEmpresa";
            this.msktbDistMaxAEmpresa.Size = new System.Drawing.Size(179, 20);
            this.msktbDistMaxAEmpresa.TabIndex = 9;
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Location = new System.Drawing.Point(224, 19);
            this.tbNombreCliente.MaxLength = 60;
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.Size = new System.Drawing.Size(179, 20);
            this.tbNombreCliente.TabIndex = 8;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(883, 43);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // tcAutorizacion
            // 
            this.tcAutorizacion.Controls.Add(this.tpAlquiler);
            this.tcAutorizacion.Controls.Add(this.tpDocumento);
            this.tcAutorizacion.Location = new System.Drawing.Point(12, 12);
            this.tcAutorizacion.Name = "tcAutorizacion";
            this.tcAutorizacion.SelectedIndex = 0;
            this.tcAutorizacion.Size = new System.Drawing.Size(984, 619);
            this.tcAutorizacion.TabIndex = 24;
            // 
            // tpAlquiler
            // 
            this.tpAlquiler.Controls.Add(this.groupBox1);
            this.tpAlquiler.Controls.Add(this.dgvAlquileres);
            this.tpAlquiler.Location = new System.Drawing.Point(4, 22);
            this.tpAlquiler.Name = "tpAlquiler";
            this.tpAlquiler.Padding = new System.Windows.Forms.Padding(3);
            this.tpAlquiler.Size = new System.Drawing.Size(976, 593);
            this.tpAlquiler.TabIndex = 0;
            this.tpAlquiler.Text = "Alquiler";
            this.tpAlquiler.UseVisualStyleBackColor = true;
            // 
            // tpDocumento
            // 
            this.tpDocumento.Controls.Add(this.dtpFechaYHora);
            this.tpDocumento.Controls.Add(this.cbTipoFertilizante);
            this.tpDocumento.Controls.Add(this.msktbNro_Documento);
            this.tpDocumento.Controls.Add(this.msktbCantidad);
            this.tpDocumento.Controls.Add(this.lblFechaHora);
            this.tpDocumento.Controls.Add(this.lblNro_Documento);
            this.tpDocumento.Controls.Add(this.lblTipoFertilizante);
            this.tpDocumento.Controls.Add(this.lblCantidad);
            this.tpDocumento.Location = new System.Drawing.Point(4, 22);
            this.tpDocumento.Name = "tpDocumento";
            this.tpDocumento.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocumento.Size = new System.Drawing.Size(976, 593);
            this.tpDocumento.TabIndex = 1;
            this.tpDocumento.Text = "Documento";
            this.tpDocumento.UseVisualStyleBackColor = true;
            // 
            // dtpFechaYHora
            // 
            this.dtpFechaYHora.Location = new System.Drawing.Point(145, 88);
            this.dtpFechaYHora.Name = "dtpFechaYHora";
            this.dtpFechaYHora.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaYHora.TabIndex = 21;
            // 
            // cbTipoFertilizante
            // 
            this.cbTipoFertilizante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFertilizante.FormattingEnabled = true;
            this.cbTipoFertilizante.Location = new System.Drawing.Point(146, 35);
            this.cbTipoFertilizante.Name = "cbTipoFertilizante";
            this.cbTipoFertilizante.Size = new System.Drawing.Size(121, 21);
            this.cbTipoFertilizante.TabIndex = 20;
            // 
            // msktbCantidad
            // 
            this.msktbCantidad.Location = new System.Drawing.Point(146, 62);
            this.msktbCantidad.Mask = "99999";
            this.msktbCantidad.Name = "msktbCantidad";
            this.msktbCantidad.Size = new System.Drawing.Size(121, 20);
            this.msktbCantidad.TabIndex = 18;
            this.msktbCantidad.ValidatingType = typeof(int);
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Location = new System.Drawing.Point(7, 91);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(74, 13);
            this.lblFechaHora.TabIndex = 16;
            this.lblFechaHora.Text = "Fecha y Hora:";
            // 
            // lblTipoFertilizante
            // 
            this.lblTipoFertilizante.AutoSize = true;
            this.lblTipoFertilizante.Location = new System.Drawing.Point(7, 38);
            this.lblTipoFertilizante.Name = "lblTipoFertilizante";
            this.lblTipoFertilizante.Size = new System.Drawing.Size(99, 13);
            this.lblTipoFertilizante.TabIndex = 14;
            this.lblTipoFertilizante.Text = "Tipo de Fertilizante:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(7, 65);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(126, 13);
            this.lblCantidad.TabIndex = 15;
            this.lblCantidad.Text = "Cantidad (en kilogramos):";
            // 
            // lblNro_Documento
            // 
            this.lblNro_Documento.AutoSize = true;
            this.lblNro_Documento.Location = new System.Drawing.Point(7, 9);
            this.lblNro_Documento.Name = "lblNro_Documento";
            this.lblNro_Documento.Size = new System.Drawing.Size(120, 13);
            this.lblNro_Documento.TabIndex = 15;
            this.lblNro_Documento.Text = "Número de Documento:";
            // 
            // msktbNro_Documento
            // 
            this.msktbNro_Documento.Location = new System.Drawing.Point(146, 6);
            this.msktbNro_Documento.Mask = "99999";
            this.msktbNro_Documento.Name = "msktbNro_Documento";
            this.msktbNro_Documento.Size = new System.Drawing.Size(121, 20);
            this.msktbNro_Documento.TabIndex = 18;
            this.msktbNro_Documento.ValidatingType = typeof(int);
            // 
            // frmAutorizarOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 696);
            this.Controls.Add(this.tcAutorizacion);
            this.Controls.Add(this.tbNotas);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAutorizar);
            this.Name = "frmAutorizarOperacion";
            this.Text = "Autorizar Operacion";
            this.Load += new System.EventHandler(this.frmAutorizarOperacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcAutorizacion.ResumeLayout(false);
            this.tpAlquiler.ResumeLayout(false);
            this.tpDocumento.ResumeLayout(false);
            this.tpDocumento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNotas;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAutorizar;
        private System.Windows.Forms.DataGridView dgvAlquileres;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox msktbSupNoUtilizadaMinima;
        private System.Windows.Forms.Label lblSuperficieNoUtilizada;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.MaskedTextBox msktbDistMaxAEmpresa;
        private System.Windows.Forms.TextBox tbNombreCliente;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TabControl tcAutorizacion;
        private System.Windows.Forms.TabPage tpAlquiler;
        private System.Windows.Forms.TabPage tpDocumento;
        private System.Windows.Forms.DateTimePicker dtpFechaYHora;
        private System.Windows.Forms.ComboBox cbTipoFertilizante;
        private System.Windows.Forms.MaskedTextBox msktbCantidad;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label lblTipoFertilizante;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.MaskedTextBox msktbNro_Documento;
        private System.Windows.Forms.Label lblNro_Documento;

    }
}
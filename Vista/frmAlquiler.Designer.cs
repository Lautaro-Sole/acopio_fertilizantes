namespace Vista
{
    partial class frmAlquiler
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
            this.gbFiltrosClientes = new System.Windows.Forms.GroupBox();
            this.btnFiltrarClientes = new System.Windows.Forms.Button();
            this.tbNombreCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.gbFiltrosAlmacenes = new System.Windows.Forms.GroupBox();
            this.btnFiltrarAlmacenes = new System.Windows.Forms.Button();
            this.mskDistanciaAEmpresMax = new System.Windows.Forms.MaskedTextBox();
            this.msktbEspacioNoAlquiladoMin = new System.Windows.Forms.MaskedTextBox();
            this.lblDistanciaMax = new System.Windows.Forms.Label();
            this.lblEspacioNoAlquiladoMin = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.dgvAlmacenes = new System.Windows.Forms.DataGridView();
            this.msktbEspacioAlquilado = new System.Windows.Forms.MaskedTextBox();
            this.lblEspacioAAlquilar = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.msktbCapacidadNoUtilizada = new System.Windows.Forms.MaskedTextBox();
            this.lblCapacidadNoUtilizada = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.msktbFecha_Hora_Inicio = new System.Windows.Forms.MaskedTextBox();
            this.msktbFecha_Hora_Fin = new System.Windows.Forms.MaskedTextBox();
            this.cbActivo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFiltrosClientes.SuspendLayout();
            this.gbFiltrosAlmacenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlmacenes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltrosClientes
            // 
            this.gbFiltrosClientes.Controls.Add(this.btnFiltrarClientes);
            this.gbFiltrosClientes.Controls.Add(this.tbNombreCliente);
            this.gbFiltrosClientes.Controls.Add(this.lblNombreCliente);
            this.gbFiltrosClientes.Location = new System.Drawing.Point(12, 12);
            this.gbFiltrosClientes.Name = "gbFiltrosClientes";
            this.gbFiltrosClientes.Size = new System.Drawing.Size(984, 66);
            this.gbFiltrosClientes.TabIndex = 0;
            this.gbFiltrosClientes.TabStop = false;
            this.gbFiltrosClientes.Text = "Filtros - Clientes";
            // 
            // btnFiltrarClientes
            // 
            this.btnFiltrarClientes.Location = new System.Drawing.Point(865, 25);
            this.btnFiltrarClientes.Name = "btnFiltrarClientes";
            this.btnFiltrarClientes.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarClientes.TabIndex = 2;
            this.btnFiltrarClientes.Text = "Filtrar";
            this.btnFiltrarClientes.UseVisualStyleBackColor = true;
            this.btnFiltrarClientes.Click += new System.EventHandler(this.btnFiltrarClientes_Click);
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Location = new System.Drawing.Point(187, 19);
            this.tbNombreCliente.MaxLength = 60;
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.Size = new System.Drawing.Size(180, 20);
            this.tbNombreCliente.TabIndex = 1;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(6, 22);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(99, 13);
            this.lblNombreCliente.TabIndex = 0;
            this.lblNombreCliente.Text = "Nombre del Cliente:";
            // 
            // gbFiltrosAlmacenes
            // 
            this.gbFiltrosAlmacenes.Controls.Add(this.btnFiltrarAlmacenes);
            this.gbFiltrosAlmacenes.Controls.Add(this.mskDistanciaAEmpresMax);
            this.gbFiltrosAlmacenes.Controls.Add(this.msktbEspacioNoAlquiladoMin);
            this.gbFiltrosAlmacenes.Controls.Add(this.lblDistanciaMax);
            this.gbFiltrosAlmacenes.Controls.Add(this.lblEspacioNoAlquiladoMin);
            this.gbFiltrosAlmacenes.Location = new System.Drawing.Point(12, 84);
            this.gbFiltrosAlmacenes.Name = "gbFiltrosAlmacenes";
            this.gbFiltrosAlmacenes.Size = new System.Drawing.Size(984, 80);
            this.gbFiltrosAlmacenes.TabIndex = 0;
            this.gbFiltrosAlmacenes.TabStop = false;
            this.gbFiltrosAlmacenes.Text = "Filtros - Almacenes";
            // 
            // btnFiltrarAlmacenes
            // 
            this.btnFiltrarAlmacenes.Location = new System.Drawing.Point(865, 29);
            this.btnFiltrarAlmacenes.Name = "btnFiltrarAlmacenes";
            this.btnFiltrarAlmacenes.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarAlmacenes.TabIndex = 2;
            this.btnFiltrarAlmacenes.Text = "Filtrar";
            this.btnFiltrarAlmacenes.UseVisualStyleBackColor = true;
            this.btnFiltrarAlmacenes.Click += new System.EventHandler(this.btnFiltrarAlmacenes_Click);
            // 
            // mskDistanciaAEmpresMax
            // 
            this.mskDistanciaAEmpresMax.Location = new System.Drawing.Point(187, 45);
            this.mskDistanciaAEmpresMax.Mask = "99999";
            this.mskDistanciaAEmpresMax.Name = "mskDistanciaAEmpresMax";
            this.mskDistanciaAEmpresMax.Size = new System.Drawing.Size(100, 20);
            this.mskDistanciaAEmpresMax.TabIndex = 3;
            // 
            // msktbEspacioNoAlquiladoMin
            // 
            this.msktbEspacioNoAlquiladoMin.Location = new System.Drawing.Point(187, 19);
            this.msktbEspacioNoAlquiladoMin.Mask = "99999";
            this.msktbEspacioNoAlquiladoMin.Name = "msktbEspacioNoAlquiladoMin";
            this.msktbEspacioNoAlquiladoMin.Size = new System.Drawing.Size(100, 20);
            this.msktbEspacioNoAlquiladoMin.TabIndex = 2;
            // 
            // lblDistanciaMax
            // 
            this.lblDistanciaMax.AutoSize = true;
            this.lblDistanciaMax.Location = new System.Drawing.Point(6, 48);
            this.lblDistanciaMax.Name = "lblDistanciaMax";
            this.lblDistanciaMax.Size = new System.Drawing.Size(155, 13);
            this.lblDistanciaMax.TabIndex = 1;
            this.lblDistanciaMax.Text = "Distancia a la empresa máxima:";
            // 
            // lblEspacioNoAlquiladoMin
            // 
            this.lblEspacioNoAlquiladoMin.AutoSize = true;
            this.lblEspacioNoAlquiladoMin.Location = new System.Drawing.Point(6, 22);
            this.lblEspacioNoAlquiladoMin.Name = "lblEspacioNoAlquiladoMin";
            this.lblEspacioNoAlquiladoMin.Size = new System.Drawing.Size(158, 13);
            this.lblEspacioNoAlquiladoMin.TabIndex = 0;
            this.lblEspacioNoAlquiladoMin.Text = "Capacidad no alquilada mínima:";
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvClientes.Location = new System.Drawing.Point(12, 170);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.Size = new System.Drawing.Size(984, 150);
            this.dgvClientes.TabIndex = 1;
            // 
            // dgvAlmacenes
            // 
            this.dgvAlmacenes.AllowUserToAddRows = false;
            this.dgvAlmacenes.AllowUserToDeleteRows = false;
            this.dgvAlmacenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlmacenes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAlmacenes.Location = new System.Drawing.Point(12, 326);
            this.dgvAlmacenes.Name = "dgvAlmacenes";
            this.dgvAlmacenes.ReadOnly = true;
            this.dgvAlmacenes.Size = new System.Drawing.Size(984, 150);
            this.dgvAlmacenes.TabIndex = 1;
            // 
            // msktbEspacioAlquilado
            // 
            this.msktbEspacioAlquilado.Location = new System.Drawing.Point(525, 506);
            this.msktbEspacioAlquilado.Mask = "99999";
            this.msktbEspacioAlquilado.Name = "msktbEspacioAlquilado";
            this.msktbEspacioAlquilado.Size = new System.Drawing.Size(100, 20);
            this.msktbEspacioAlquilado.TabIndex = 2;
            // 
            // lblEspacioAAlquilar
            // 
            this.lblEspacioAAlquilar.AutoSize = true;
            this.lblEspacioAAlquilar.Location = new System.Drawing.Point(373, 509);
            this.lblEspacioAAlquilar.Name = "lblEspacioAAlquilar";
            this.lblEspacioAAlquilar.Size = new System.Drawing.Size(98, 13);
            this.lblEspacioAAlquilar.TabIndex = 3;
            this.lblEspacioAAlquilar.Text = "Capacidad (en Kg):";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 650);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(921, 650);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // msktbCapacidadNoUtilizada
            // 
            this.msktbCapacidadNoUtilizada.Location = new System.Drawing.Point(525, 607);
            this.msktbCapacidadNoUtilizada.Mask = "99999";
            this.msktbCapacidadNoUtilizada.Name = "msktbCapacidadNoUtilizada";
            this.msktbCapacidadNoUtilizada.Size = new System.Drawing.Size(100, 20);
            this.msktbCapacidadNoUtilizada.TabIndex = 2;
            // 
            // lblCapacidadNoUtilizada
            // 
            this.lblCapacidadNoUtilizada.AutoSize = true;
            this.lblCapacidadNoUtilizada.Location = new System.Drawing.Point(373, 610);
            this.lblCapacidadNoUtilizada.Name = "lblCapacidadNoUtilizada";
            this.lblCapacidadNoUtilizada.Size = new System.Drawing.Size(121, 13);
            this.lblCapacidadNoUtilizada.TabIndex = 3;
            this.lblCapacidadNoUtilizada.Text = "Capacidad No Utilizada:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(373, 535);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(117, 13);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha y Hora de Inicio:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(373, 561);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(147, 13);
            this.lblFechaFin.TabIndex = 6;
            this.lblFechaFin.Text = "Fecha y Hora de Finalización:";
            // 
            // msktbFecha_Hora_Inicio
            // 
            this.msktbFecha_Hora_Inicio.Location = new System.Drawing.Point(525, 532);
            this.msktbFecha_Hora_Inicio.Mask = "00/00/0000 00:00";
            this.msktbFecha_Hora_Inicio.Name = "msktbFecha_Hora_Inicio";
            this.msktbFecha_Hora_Inicio.Size = new System.Drawing.Size(100, 20);
            this.msktbFecha_Hora_Inicio.TabIndex = 7;
            this.msktbFecha_Hora_Inicio.ValidatingType = typeof(System.DateTime);
            // 
            // msktbFecha_Hora_Fin
            // 
            this.msktbFecha_Hora_Fin.Location = new System.Drawing.Point(525, 558);
            this.msktbFecha_Hora_Fin.Mask = "00/00/0000 00:00";
            this.msktbFecha_Hora_Fin.Name = "msktbFecha_Hora_Fin";
            this.msktbFecha_Hora_Fin.Size = new System.Drawing.Size(100, 20);
            this.msktbFecha_Hora_Fin.TabIndex = 7;
            this.msktbFecha_Hora_Fin.ValidatingType = typeof(System.DateTime);
            // 
            // cbActivo
            // 
            this.cbActivo.AutoSize = true;
            this.cbActivo.Location = new System.Drawing.Point(525, 584);
            this.cbActivo.Name = "cbActivo";
            this.cbActivo.Size = new System.Drawing.Size(15, 14);
            this.cbActivo.TabIndex = 8;
            this.cbActivo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Activo:";
            // 
            // frmAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 692);
            this.Controls.Add(this.cbActivo);
            this.Controls.Add(this.msktbFecha_Hora_Fin);
            this.Controls.Add(this.msktbFecha_Hora_Inicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblCapacidadNoUtilizada);
            this.Controls.Add(this.lblEspacioAAlquilar);
            this.Controls.Add(this.msktbCapacidadNoUtilizada);
            this.Controls.Add(this.msktbEspacioAlquilado);
            this.Controls.Add(this.dgvAlmacenes);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.gbFiltrosAlmacenes);
            this.Controls.Add(this.gbFiltrosClientes);
            this.Name = "frmAlquiler";
            this.Text = "Alquiler";
            this.Load += new System.EventHandler(this.frmAlquiler_Load);
            this.gbFiltrosClientes.ResumeLayout(false);
            this.gbFiltrosClientes.PerformLayout();
            this.gbFiltrosAlmacenes.ResumeLayout(false);
            this.gbFiltrosAlmacenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlmacenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltrosClientes;
        private System.Windows.Forms.Button btnFiltrarClientes;
        private System.Windows.Forms.TextBox tbNombreCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.GroupBox gbFiltrosAlmacenes;
        private System.Windows.Forms.Button btnFiltrarAlmacenes;
        private System.Windows.Forms.MaskedTextBox mskDistanciaAEmpresMax;
        private System.Windows.Forms.MaskedTextBox msktbEspacioNoAlquiladoMin;
        private System.Windows.Forms.Label lblDistanciaMax;
        private System.Windows.Forms.Label lblEspacioNoAlquiladoMin;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridView dgvAlmacenes;
        private System.Windows.Forms.MaskedTextBox msktbEspacioAlquilado;
        private System.Windows.Forms.Label lblEspacioAAlquilar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox msktbCapacidadNoUtilizada;
        private System.Windows.Forms.Label lblCapacidadNoUtilizada;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.MaskedTextBox msktbFecha_Hora_Inicio;
        private System.Windows.Forms.MaskedTextBox msktbFecha_Hora_Fin;
        private System.Windows.Forms.CheckBox cbActivo;
        private System.Windows.Forms.Label label1;
    }
}
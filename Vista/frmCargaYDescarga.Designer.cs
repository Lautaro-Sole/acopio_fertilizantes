namespace Vista
{
    partial class frmCargaYDescarga
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnRegistrarDescarga = new System.Windows.Forms.Button();
            this.btnRegistrarCarga = new System.Windows.Forms.Button();
            this.dgvOperaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cbOperacion = new System.Windows.Forms.ComboBox();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.tbNombreCliente = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblNumId = new System.Windows.Forms.Label();
            this.cbTipo_Id = new System.Windows.Forms.ComboBox();
            this.tbNum_Id = new System.Windows.Forms.TextBox();
            this.lblTipoId = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(609, 492);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarDescarga
            // 
            this.btnRegistrarDescarga.Location = new System.Drawing.Point(405, 492);
            this.btnRegistrarDescarga.Name = "btnRegistrarDescarga";
            this.btnRegistrarDescarga.Size = new System.Drawing.Size(120, 23);
            this.btnRegistrarDescarga.TabIndex = 10;
            this.btnRegistrarDescarga.Text = "Registrar Descarga";
            this.btnRegistrarDescarga.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarCarga
            // 
            this.btnRegistrarCarga.Location = new System.Drawing.Point(146, 491);
            this.btnRegistrarCarga.Name = "btnRegistrarCarga";
            this.btnRegistrarCarga.Size = new System.Drawing.Size(120, 23);
            this.btnRegistrarCarga.TabIndex = 9;
            this.btnRegistrarCarga.Text = "Registrar Carga";
            this.btnRegistrarCarga.UseVisualStyleBackColor = true;
            this.btnRegistrarCarga.Click += new System.EventHandler(this.btnRegistrarCarga_Click);
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.AllowUserToAddRows = false;
            this.dgvOperaciones.AllowUserToDeleteRows = false;
            this.dgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOperaciones.Location = new System.Drawing.Point(12, 118);
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.ReadOnly = true;
            this.dgvOperaciones.Size = new System.Drawing.Size(760, 367);
            this.dgvOperaciones.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEstado);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.cbOperacion);
            this.groupBox1.Controls.Add(this.lblOperacion);
            this.groupBox1.Controls.Add(this.tbNombreCliente);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.lblNumId);
            this.groupBox1.Controls.Add(this.cbTipo_Id);
            this.groupBox1.Controls.Add(this.tbNum_Id);
            this.groupBox1.Controls.Add(this.lblTipoId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Ingresa",
            "Autorizado",
            "Terminado",
            "Cerrado"});
            this.cbEstado.Location = new System.Drawing.Point(442, 46);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(121, 21);
            this.cbEstado.TabIndex = 14;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(299, 49);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 15;
            this.lblEstado.Text = "Estado:";
            // 
            // cbOperacion
            // 
            this.cbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperacion.FormattingEnabled = true;
            this.cbOperacion.Items.AddRange(new object[] {
            "Carga",
            "Descarga"});
            this.cbOperacion.Location = new System.Drawing.Point(442, 19);
            this.cbOperacion.Name = "cbOperacion";
            this.cbOperacion.Size = new System.Drawing.Size(121, 21);
            this.cbOperacion.TabIndex = 12;
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Location = new System.Drawing.Point(299, 22);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(98, 13);
            this.lblOperacion.TabIndex = 13;
            this.lblOperacion.Text = "Tipo de Operación:";
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Location = new System.Drawing.Point(151, 72);
            this.tbNombreCliente.MaxLength = 60;
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.Size = new System.Drawing.Size(121, 20);
            this.tbNombreCliente.TabIndex = 11;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(679, 41);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(8, 75);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(99, 13);
            this.lblCliente.TabIndex = 10;
            this.lblCliente.Text = "Nombre del Cliente:";
            // 
            // lblNumId
            // 
            this.lblNumId.AutoSize = true;
            this.lblNumId.Location = new System.Drawing.Point(8, 51);
            this.lblNumId.Name = "lblNumId";
            this.lblNumId.Size = new System.Drawing.Size(76, 13);
            this.lblNumId.TabIndex = 8;
            this.lblNumId.Text = "Número de ID:";
            // 
            // cbTipo_Id
            // 
            this.cbTipo_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo_Id.FormattingEnabled = true;
            this.cbTipo_Id.Items.AddRange(new object[] {
            "Patente"});
            this.cbTipo_Id.Location = new System.Drawing.Point(151, 19);
            this.cbTipo_Id.Name = "cbTipo_Id";
            this.cbTipo_Id.Size = new System.Drawing.Size(121, 21);
            this.cbTipo_Id.TabIndex = 6;
            // 
            // tbNum_Id
            // 
            this.tbNum_Id.Location = new System.Drawing.Point(151, 46);
            this.tbNum_Id.Name = "tbNum_Id";
            this.tbNum_Id.Size = new System.Drawing.Size(121, 20);
            this.tbNum_Id.TabIndex = 9;
            // 
            // lblTipoId
            // 
            this.lblTipoId.AutoSize = true;
            this.lblTipoId.Location = new System.Drawing.Point(8, 22);
            this.lblTipoId.Name = "lblTipoId";
            this.lblTipoId.Size = new System.Drawing.Size(60, 13);
            this.lblTipoId.TabIndex = 7;
            this.lblTipoId.Text = "Tipo de ID:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(247, 527);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(162, 23);
            this.btnRegistrar.TabIndex = 13;
            this.btnRegistrar.Text = "Registrar Carga o Descarga";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // frmCargaYDescarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnRegistrarDescarga);
            this.Controls.Add(this.btnRegistrarCarga);
            this.Controls.Add(this.dgvOperaciones);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCargaYDescarga";
            this.Text = "Carga y Descarga";
            this.Load += new System.EventHandler(this.frmCargaYDescarga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnRegistrarDescarga;
        private System.Windows.Forms.Button btnRegistrarCarga;
        private System.Windows.Forms.DataGridView dgvOperaciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cbOperacion;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.TextBox tbNombreCliente;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblNumId;
        private System.Windows.Forms.ComboBox cbTipo_Id;
        private System.Windows.Forms.TextBox tbNum_Id;
        private System.Windows.Forms.Label lblTipoId;
        private System.Windows.Forms.Button btnRegistrar;
    }
}
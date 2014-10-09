namespace Vista
{
    partial class frmChoferes
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvChoferes = new System.Windows.Forms.DataGridView();
            this.lblApellido = new System.Windows.Forms.Label();
            this.cbTipo_Documento = new System.Windows.Forms.ComboBox();
            this.msktbDocumento = new System.Windows.Forms.MaskedTextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.tbCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoferes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.lblCliente);
            this.gbFiltros.Controls.Add(this.tbCliente);
            this.gbFiltros.Controls.Add(this.lblNombre);
            this.gbFiltros.Controls.Add(this.lblApellido);
            this.gbFiltros.Controls.Add(this.cbTipo_Documento);
            this.gbFiltros.Controls.Add(this.msktbDocumento);
            this.gbFiltros.Controls.Add(this.tbApellido);
            this.gbFiltros.Controls.Add(this.tbNombre);
            this.gbFiltros.Controls.Add(this.lblDistancia);
            this.gbFiltros.Controls.Add(this.lblDireccion);
            this.gbFiltros.Controls.SetChildIndex(this.lblDireccion, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblDistancia, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbApellido, 0);
            this.gbFiltros.Controls.SetChildIndex(this.msktbDocumento, 0);
            this.gbFiltros.Controls.SetChildIndex(this.cbTipo_Documento, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblApellido, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblNombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbCliente, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblCliente, 0);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvChoferes
            // 
            this.dgvChoferes.AllowUserToAddRows = false;
            this.dgvChoferes.AllowUserToDeleteRows = false;
            this.dgvChoferes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoferes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvChoferes.Location = new System.Drawing.Point(12, 136);
            this.dgvChoferes.Name = "dgvChoferes";
            this.dgvChoferes.ReadOnly = true;
            this.dgvChoferes.Size = new System.Drawing.Size(984, 512);
            this.dgvChoferes.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(70, 43);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 33;
            this.lblApellido.Text = "Apellido:";
            // 
            // cbTipo_Documento
            // 
            this.cbTipo_Documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo_Documento.FormattingEnabled = true;
            this.cbTipo_Documento.Items.AddRange(new object[] {
            "LC",
            "LE",
            "DNI"});
            this.cbTipo_Documento.Location = new System.Drawing.Point(542, 40);
            this.cbTipo_Documento.Name = "cbTipo_Documento";
            this.cbTipo_Documento.Size = new System.Drawing.Size(177, 21);
            this.cbTipo_Documento.TabIndex = 32;
            // 
            // msktbDocumento
            // 
            this.msktbDocumento.Location = new System.Drawing.Point(542, 67);
            this.msktbDocumento.Mask = "99999999";
            this.msktbDocumento.Name = "msktbDocumento";
            this.msktbDocumento.Size = new System.Drawing.Size(177, 20);
            this.msktbDocumento.TabIndex = 31;
            this.msktbDocumento.ValidatingType = typeof(int);
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(194, 19);
            this.tbNombre.MaxLength = 30;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(177, 20);
            this.tbNombre.TabIndex = 30;
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.Location = new System.Drawing.Point(385, 70);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(120, 13);
            this.lblDistancia.TabIndex = 29;
            this.lblDistancia.Text = "Número de Documento:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(385, 43);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(104, 13);
            this.lblDireccion.TabIndex = 28;
            this.lblDireccion.Text = "Tipo de Documento:";
            // 
            // tbCliente
            // 
            this.tbCliente.Location = new System.Drawing.Point(194, 66);
            this.tbCliente.Name = "tbCliente";
            this.tbCliente.Size = new System.Drawing.Size(177, 20);
            this.tbCliente.TabIndex = 34;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(70, 69);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 35;
            this.lblCliente.Text = "Cliente:";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(194, 43);
            this.tbApellido.MaxLength = 30;
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(177, 20);
            this.tbApellido.TabIndex = 30;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(70, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 33;
            this.lblNombre.Text = "Nombre:";
            // 
            // frmChoferes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.dgvChoferes);
            this.Name = "frmChoferes";
            this.Text = "Choferes";
            this.Load += new System.EventHandler(this.frmChoferes_Load);
            this.Controls.SetChildIndex(this.dgvChoferes, 0);
            this.Controls.SetChildIndex(this.gbFiltros, 0);
            this.Controls.SetChildIndex(this.gbAcciones, 0);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoferes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChoferes;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.ComboBox cbTipo_Documento;
        private System.Windows.Forms.MaskedTextBox msktbDocumento;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox tbCliente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbApellido;
    }
}

namespace Vista
{
    partial class frmAlquileres
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
            this.dgvAlquileres = new System.Windows.Forms.DataGridView();
            this.tbNombreCliente = new System.Windows.Forms.TextBox();
            this.msktbDistMaxAEmpresa = new System.Windows.Forms.MaskedTextBox();
            this.msktbCapacidadNoUtilizadaMinima = new System.Windows.Forms.MaskedTextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.lblSuperficieNoUtilizada = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.msktbCapacidadNoUtilizadaMinima);
            this.gbFiltros.Controls.Add(this.lblSuperficieNoUtilizada);
            this.gbFiltros.Controls.Add(this.lblDistancia);
            this.gbFiltros.Controls.Add(this.lblNombreCliente);
            this.gbFiltros.Controls.Add(this.msktbDistMaxAEmpresa);
            this.gbFiltros.Controls.Add(this.tbNombreCliente);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombreCliente, 0);
            this.gbFiltros.Controls.SetChildIndex(this.msktbDistMaxAEmpresa, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblNombreCliente, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblDistancia, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblSuperficieNoUtilizada, 0);
            this.gbFiltros.Controls.SetChildIndex(this.msktbCapacidadNoUtilizadaMinima, 0);
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
            // dgvAlquileres
            // 
            this.dgvAlquileres.AllowUserToAddRows = false;
            this.dgvAlquileres.AllowUserToDeleteRows = false;
            this.dgvAlquileres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlquileres.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAlquileres.Location = new System.Drawing.Point(12, 136);
            this.dgvAlquileres.Name = "dgvAlquileres";
            this.dgvAlquileres.ReadOnly = true;
            this.dgvAlquileres.Size = new System.Drawing.Size(984, 512);
            this.dgvAlquileres.TabIndex = 3;
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Location = new System.Drawing.Point(292, 19);
            this.tbNombreCliente.MaxLength = 60;
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.Size = new System.Drawing.Size(179, 20);
            this.tbNombreCliente.TabIndex = 2;
            // 
            // msktbDistMaxAEmpresa
            // 
            this.msktbDistMaxAEmpresa.Location = new System.Drawing.Point(292, 71);
            this.msktbDistMaxAEmpresa.Mask = "99999";
            this.msktbDistMaxAEmpresa.Name = "msktbDistMaxAEmpresa";
            this.msktbDistMaxAEmpresa.Size = new System.Drawing.Size(179, 20);
            this.msktbDistMaxAEmpresa.TabIndex = 3;
            // 
            // msktbCapacidadNoUtilizadaMinima
            // 
            this.msktbCapacidadNoUtilizadaMinima.Location = new System.Drawing.Point(292, 45);
            this.msktbCapacidadNoUtilizadaMinima.Mask = "99999";
            this.msktbCapacidadNoUtilizadaMinima.Name = "msktbCapacidadNoUtilizadaMinima";
            this.msktbCapacidadNoUtilizadaMinima.Size = new System.Drawing.Size(179, 20);
            this.msktbCapacidadNoUtilizadaMinima.TabIndex = 4;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(74, 22);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(99, 13);
            this.lblNombreCliente.TabIndex = 5;
            this.lblNombreCliente.Text = "Nombre del Cliente:";
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.Location = new System.Drawing.Point(74, 48);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(157, 13);
            this.lblDistancia.TabIndex = 6;
            this.lblDistancia.Text = "Capacidad no Utilizada Mínima:";
            // 
            // lblSuperficieNoUtilizada
            // 
            this.lblSuperficieNoUtilizada.AutoSize = true;
            this.lblSuperficieNoUtilizada.Location = new System.Drawing.Point(74, 74);
            this.lblSuperficieNoUtilizada.Name = "lblSuperficieNoUtilizada";
            this.lblSuperficieNoUtilizada.Size = new System.Drawing.Size(156, 13);
            this.lblSuperficieNoUtilizada.TabIndex = 7;
            this.lblSuperficieNoUtilizada.Text = "Distancia Máxima a la empresa:";
            // 
            // frmAlquileres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.dgvAlquileres);
            this.Name = "frmAlquileres";
            this.Text = "Alquileres";
            this.Load += new System.EventHandler(this.frmAlquileres_Load);
            this.Controls.SetChildIndex(this.dgvAlquileres, 0);
            this.Controls.SetChildIndex(this.gbFiltros, 0);
            this.Controls.SetChildIndex(this.gbAcciones, 0);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlquileres;
        private System.Windows.Forms.MaskedTextBox msktbCapacidadNoUtilizadaMinima;
        private System.Windows.Forms.Label lblSuperficieNoUtilizada;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.MaskedTextBox msktbDistMaxAEmpresa;
        private System.Windows.Forms.TextBox tbNombreCliente;
    }
}

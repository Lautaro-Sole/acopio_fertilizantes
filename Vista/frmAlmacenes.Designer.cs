namespace Vista
{
    partial class frmAlmacenes
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
            this.lblNombreAlmacen = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.dgvAlmacenes = new System.Windows.Forms.DataGridView();
            this.msktbCapacidad = new System.Windows.Forms.MaskedTextBox();
            this.lblEspacio = new System.Windows.Forms.Label();
            this.msktbDistancia = new System.Windows.Forms.MaskedTextBox();
            this.gbFiltros.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlmacenes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.msktbDistancia);
            this.gbFiltros.Controls.Add(this.msktbCapacidad);
            this.gbFiltros.Controls.Add(this.lblDistancia);
            this.gbFiltros.Controls.Add(this.tbNombre);
            this.gbFiltros.Controls.Add(this.lblEspacio);
            this.gbFiltros.Controls.Add(this.lblNombreAlmacen);
            this.gbFiltros.Controls.SetChildIndex(this.lblNombreAlmacen, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblEspacio, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombre, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblDistancia, 0);
            this.gbFiltros.Controls.SetChildIndex(this.msktbCapacidad, 0);
            this.gbFiltros.Controls.SetChildIndex(this.msktbDistancia, 0);
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
            // lblNombreAlmacen
            // 
            this.lblNombreAlmacen.AutoSize = true;
            this.lblNombreAlmacen.Location = new System.Drawing.Point(63, 22);
            this.lblNombreAlmacen.Name = "lblNombreAlmacen";
            this.lblNombreAlmacen.Size = new System.Drawing.Size(108, 13);
            this.lblNombreAlmacen.TabIndex = 1;
            this.lblNombreAlmacen.Text = "Nombre del Almacén:";
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.Location = new System.Drawing.Point(63, 55);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Size = new System.Drawing.Size(93, 13);
            this.lblDistancia.TabIndex = 2;
            this.lblDistancia.Text = "Distancia Máxima:";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(185, 19);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(100, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // dgvAlmacenes
            // 
            this.dgvAlmacenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlmacenes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAlmacenes.Location = new System.Drawing.Point(12, 136);
            this.dgvAlmacenes.Name = "dgvAlmacenes";
            this.dgvAlmacenes.ReadOnly = true;
            this.dgvAlmacenes.Size = new System.Drawing.Size(984, 512);
            this.dgvAlmacenes.TabIndex = 3;
            // 
            // msktbCapacidad
            // 
            this.msktbCapacidad.Location = new System.Drawing.Point(405, 19);
            this.msktbCapacidad.Mask = "99999";
            this.msktbCapacidad.Name = "msktbCapacidad";
            this.msktbCapacidad.Size = new System.Drawing.Size(100, 20);
            this.msktbCapacidad.TabIndex = 5;
            this.msktbCapacidad.ValidatingType = typeof(int);
            // 
            // lblEspacio
            // 
            this.lblEspacio.AutoSize = true;
            this.lblEspacio.Location = new System.Drawing.Point(300, 22);
            this.lblEspacio.Name = "lblEspacio";
            this.lblEspacio.Size = new System.Drawing.Size(99, 13);
            this.lblEspacio.TabIndex = 1;
            this.lblEspacio.Text = "Capacidad Mínima:";
            // 
            // msktbDistancia
            // 
            this.msktbDistancia.Location = new System.Drawing.Point(185, 52);
            this.msktbDistancia.Mask = "99999";
            this.msktbDistancia.Name = "msktbDistancia";
            this.msktbDistancia.Size = new System.Drawing.Size(100, 20);
            this.msktbDistancia.TabIndex = 5;
            this.msktbDistancia.ValidatingType = typeof(int);
            // 
            // frmAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.dgvAlmacenes);
            this.Name = "frmAlmacenes";
            this.Text = "Almacenes";
            this.Load += new System.EventHandler(this.frmAlmacenes_Load);
            this.Controls.SetChildIndex(this.dgvAlmacenes, 0);
            this.Controls.SetChildIndex(this.gbFiltros, 0);
            this.Controls.SetChildIndex(this.gbAcciones, 0);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlmacenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNombreAlmacen;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.DataGridView dgvAlmacenes;
        private System.Windows.Forms.MaskedTextBox msktbCapacidad;
        private System.Windows.Forms.Label lblEspacio;
        private System.Windows.Forms.MaskedTextBox msktbDistancia;
    }
}

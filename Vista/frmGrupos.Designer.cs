namespace Vista
{
    partial class frmGrupos
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
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.tbDescripcionGrupo = new System.Windows.Forms.TextBox();
            this.cbEstadoGrupo = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.lblDescripcion);
            this.gbFiltros.Controls.Add(this.lblEstado);
            this.gbFiltros.Controls.Add(this.tbDescripcionGrupo);
            this.gbFiltros.Controls.Add(this.cbEstadoGrupo);
            this.gbFiltros.Controls.SetChildIndex(this.cbEstadoGrupo, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbDescripcionGrupo, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblEstado, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblDescripcion, 0);
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
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGrupos.Location = new System.Drawing.Point(6, 136);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.Size = new System.Drawing.Size(984, 512);
            this.dgvGrupos.TabIndex = 3;
            // 
            // tbDescripcionGrupo
            // 
            this.tbDescripcionGrupo.Location = new System.Drawing.Point(216, 30);
            this.tbDescripcionGrupo.MaxLength = 50;
            this.tbDescripcionGrupo.Name = "tbDescripcionGrupo";
            this.tbDescripcionGrupo.Size = new System.Drawing.Size(220, 20);
            this.tbDescripcionGrupo.TabIndex = 1;
            // 
            // cbEstadoGrupo
            // 
            this.cbEstadoGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoGrupo.FormattingEnabled = true;
            this.cbEstadoGrupo.Items.AddRange(new object[] {
            "TODOS",
            "Activos",
            "Inactivos"});
            this.cbEstadoGrupo.Location = new System.Drawing.Point(216, 56);
            this.cbEstadoGrupo.Name = "cbEstadoGrupo";
            this.cbEstadoGrupo.Size = new System.Drawing.Size(121, 21);
            this.cbEstadoGrupo.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(112, 33);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(112, 59);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";
            // 
            // frmGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.dgvGrupos);
            this.Name = "frmGrupos";
            this.Text = "Grupos";
            this.Load += new System.EventHandler(this.frmGrupos_Load);
            this.Controls.SetChildIndex(this.dgvGrupos, 0);
            this.Controls.SetChildIndex(this.gbFiltros, 0);
            this.Controls.SetChildIndex(this.gbAcciones, 0);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.TextBox tbDescripcionGrupo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cbEstadoGrupo;
    }
}

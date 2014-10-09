namespace Vista
{
    partial class frmPerfiles
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
            this.cbGrupos = new System.Windows.Forms.ComboBox();
            this.cbFormularios = new System.Windows.Forms.ComboBox();
            this.cbPermisos = new System.Windows.Forms.ComboBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.lblPermiso = new System.Windows.Forms.Label();
            this.dgvPerfiles = new System.Windows.Forms.DataGridView();
            this.gbFiltros.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.lblGrupo);
            this.gbFiltros.Controls.Add(this.lblPermiso);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.cbGrupos);
            this.gbFiltros.Controls.Add(this.cbFormularios);
            this.gbFiltros.Controls.Add(this.lblFormulario);
            this.gbFiltros.Controls.Add(this.cbPermisos);
            this.gbFiltros.Controls.SetChildIndex(this.cbPermisos, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblFormulario, 0);
            this.gbFiltros.Controls.SetChildIndex(this.cbFormularios, 0);
            this.gbFiltros.Controls.SetChildIndex(this.cbGrupos, 0);
            this.gbFiltros.Controls.SetChildIndex(this.label2, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblPermiso, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblGrupo, 0);
            // 
            // gbAcciones
            // 
            this.gbAcciones.Enter += new System.EventHandler(this.gbAcciones_Enter);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cbGrupos
            // 
            this.cbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupos.FormattingEnabled = true;
            this.cbGrupos.Location = new System.Drawing.Point(123, 19);
            this.cbGrupos.Name = "cbGrupos";
            this.cbGrupos.Size = new System.Drawing.Size(121, 21);
            this.cbGrupos.TabIndex = 1;
            // 
            // cbFormularios
            // 
            this.cbFormularios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormularios.FormattingEnabled = true;
            this.cbFormularios.Location = new System.Drawing.Point(123, 46);
            this.cbFormularios.Name = "cbFormularios";
            this.cbFormularios.Size = new System.Drawing.Size(121, 21);
            this.cbFormularios.TabIndex = 1;
            // 
            // cbPermisos
            // 
            this.cbPermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPermisos.FormattingEnabled = true;
            this.cbPermisos.Location = new System.Drawing.Point(123, 73);
            this.cbPermisos.Name = "cbPermisos";
            this.cbPermisos.Size = new System.Drawing.Size(121, 21);
            this.cbPermisos.TabIndex = 1;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(14, 23);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 2;
            this.lblGrupo.Text = "Grupo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grupo:";
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Location = new System.Drawing.Point(14, 49);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(58, 13);
            this.lblFormulario.TabIndex = 2;
            this.lblFormulario.Text = "Formulario:";
            // 
            // lblPermiso
            // 
            this.lblPermiso.AutoSize = true;
            this.lblPermiso.Location = new System.Drawing.Point(14, 76);
            this.lblPermiso.Name = "lblPermiso";
            this.lblPermiso.Size = new System.Drawing.Size(47, 13);
            this.lblPermiso.TabIndex = 2;
            this.lblPermiso.Text = "Permiso:";
            // 
            // dgvPerfiles
            // 
            this.dgvPerfiles.AllowUserToAddRows = false;
            this.dgvPerfiles.AllowUserToDeleteRows = false;
            this.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPerfiles.Location = new System.Drawing.Point(12, 136);
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.ReadOnly = true;
            this.dgvPerfiles.Size = new System.Drawing.Size(984, 512);
            this.dgvPerfiles.TabIndex = 3;
            // 
            // frmPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.dgvPerfiles);
            this.Name = "frmPerfiles";
            this.Text = "Perfiles";
            this.Load += new System.EventHandler(this.frmPerfiles_Load);
            this.Controls.SetChildIndex(this.dgvPerfiles, 0);
            this.Controls.SetChildIndex(this.gbFiltros, 0);
            this.Controls.SetChildIndex(this.gbAcciones, 0);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblPermiso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGrupos;
        private System.Windows.Forms.ComboBox cbFormularios;
        private System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.ComboBox cbPermisos;
        private System.Windows.Forms.DataGridView dgvPerfiles;
    }
}

namespace Vista
{
    partial class frmTransportes
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
            this.dgvTransportes = new System.Windows.Forms.DataGridView();
            this.cbTipo_Matricula = new System.Windows.Forms.ComboBox();
            this.lblTipoMatricula = new System.Windows.Forms.Label();
            this.lblNumMatricula = new System.Windows.Forms.Label();
            this.tbNum_Matricula = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tbNombreCliente = new System.Windows.Forms.TextBox();
            this.lblNombreChofer = new System.Windows.Forms.Label();
            this.tbNombreChofer = new System.Windows.Forms.TextBox();
            this.gbFiltros.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.tbNombreChofer);
            this.gbFiltros.Controls.Add(this.lblNombreChofer);
            this.gbFiltros.Controls.Add(this.tbNombreCliente);
            this.gbFiltros.Controls.Add(this.lblCliente);
            this.gbFiltros.Controls.Add(this.lblNumMatricula);
            this.gbFiltros.Controls.Add(this.tbNum_Matricula);
            this.gbFiltros.Controls.Add(this.lblTipoMatricula);
            this.gbFiltros.Controls.Add(this.cbTipo_Matricula);
            this.gbFiltros.Controls.SetChildIndex(this.cbTipo_Matricula, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblTipoMatricula, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbNum_Matricula, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblNumMatricula, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblCliente, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombreCliente, 0);
            this.gbFiltros.Controls.SetChildIndex(this.lblNombreChofer, 0);
            this.gbFiltros.Controls.SetChildIndex(this.tbNombreChofer, 0);
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
            // dgvTransportes
            // 
            this.dgvTransportes.AllowUserToAddRows = false;
            this.dgvTransportes.AllowUserToDeleteRows = false;
            this.dgvTransportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransportes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTransportes.Location = new System.Drawing.Point(12, 136);
            this.dgvTransportes.Name = "dgvTransportes";
            this.dgvTransportes.ReadOnly = true;
            this.dgvTransportes.Size = new System.Drawing.Size(984, 512);
            this.dgvTransportes.TabIndex = 3;
            // 
            // cbTipo_Matricula
            // 
            this.cbTipo_Matricula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo_Matricula.FormattingEnabled = true;
            this.cbTipo_Matricula.Items.AddRange(new object[] {
            "Patente"});
            this.cbTipo_Matricula.Location = new System.Drawing.Point(161, 25);
            this.cbTipo_Matricula.Name = "cbTipo_Matricula";
            this.cbTipo_Matricula.Size = new System.Drawing.Size(121, 21);
            this.cbTipo_Matricula.TabIndex = 1;
            // 
            // lblTipoMatricula
            // 
            this.lblTipoMatricula.AutoSize = true;
            this.lblTipoMatricula.Location = new System.Drawing.Point(18, 28);
            this.lblTipoMatricula.Name = "lblTipoMatricula";
            this.lblTipoMatricula.Size = new System.Drawing.Size(94, 13);
            this.lblTipoMatricula.TabIndex = 2;
            this.lblTipoMatricula.Text = "Tipo de Matrícula:";
            // 
            // lblNumMatricula
            // 
            this.lblNumMatricula.AutoSize = true;
            this.lblNumMatricula.Location = new System.Drawing.Point(18, 57);
            this.lblNumMatricula.Name = "lblNumMatricula";
            this.lblNumMatricula.Size = new System.Drawing.Size(110, 13);
            this.lblNumMatricula.TabIndex = 2;
            this.lblNumMatricula.Text = "Número de Matrícula:";
            // 
            // tbNum_Matricula
            // 
            this.tbNum_Matricula.Location = new System.Drawing.Point(161, 52);
            this.tbNum_Matricula.Name = "tbNum_Matricula";
            this.tbNum_Matricula.Size = new System.Drawing.Size(121, 20);
            this.tbNum_Matricula.TabIndex = 3;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(18, 81);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(99, 13);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Nombre del Cliente:";
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Location = new System.Drawing.Point(161, 78);
            this.tbNombreCliente.MaxLength = 60;
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.Size = new System.Drawing.Size(121, 20);
            this.tbNombreCliente.TabIndex = 5;
            // 
            // lblNombreChofer
            // 
            this.lblNombreChofer.AutoSize = true;
            this.lblNombreChofer.Location = new System.Drawing.Point(300, 28);
            this.lblNombreChofer.Name = "lblNombreChofer";
            this.lblNombreChofer.Size = new System.Drawing.Size(98, 13);
            this.lblNombreChofer.TabIndex = 4;
            this.lblNombreChofer.Text = "Nombre del Chofer:";
            // 
            // tbNombreChofer
            // 
            this.tbNombreChofer.Location = new System.Drawing.Point(437, 25);
            this.tbNombreChofer.MaxLength = 30;
            this.tbNombreChofer.Name = "tbNombreChofer";
            this.tbNombreChofer.Size = new System.Drawing.Size(121, 20);
            this.tbNombreChofer.TabIndex = 5;
            // 
            // frmTransportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.dgvTransportes);
            this.Name = "frmTransportes";
            this.Text = "Transportes";
            this.Load += new System.EventHandler(this.frmTransportes_Load);
            this.Controls.SetChildIndex(this.dgvTransportes, 0);
            this.Controls.SetChildIndex(this.gbFiltros, 0);
            this.Controls.SetChildIndex(this.gbAcciones, 0);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNumMatricula;
        private System.Windows.Forms.TextBox tbNum_Matricula;
        private System.Windows.Forms.Label lblTipoMatricula;
        private System.Windows.Forms.ComboBox cbTipo_Matricula;
        private System.Windows.Forms.DataGridView dgvTransportes;
        private System.Windows.Forms.TextBox tbNombreCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox tbNombreChofer;
        private System.Windows.Forms.Label lblNombreChofer;
    }
}

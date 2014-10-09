namespace Vista
{
    partial class frmInformeFertMovido
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.FertilizanteMovido_ClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetInformes = new Vista.DataSetInformes();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAnio = new System.Windows.Forms.DateTimePicker();
            this.cbSemestre = new System.Windows.Forms.ComboBox();
            this.dgvCantidadFertMovido = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.rvFertilizanteMovido = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FertilizanteMovido_ClientesTableAdapter = new Vista.DataSetInformesTableAdapters.FertilizanteMovido_ClientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FertilizanteMovido_ClientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantidadFertMovido)).BeginInit();
            this.SuspendLayout();
            // 
            // FertilizanteMovido_ClientesBindingSource
            // 
            this.FertilizanteMovido_ClientesBindingSource.DataMember = "FertilizanteMovido_Clientes";
            this.FertilizanteMovido_ClientesBindingSource.DataSource = this.DataSetInformes;
            // 
            // DataSetInformes
            // 
            this.DataSetInformes.DataSetName = "DataSetInformes";
            this.DataSetInformes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Semestre:";
            // 
            // dtpAnio
            // 
            this.dtpAnio.Location = new System.Drawing.Point(91, 9);
            this.dtpAnio.Name = "dtpAnio";
            this.dtpAnio.Size = new System.Drawing.Size(200, 20);
            this.dtpAnio.TabIndex = 1;
            // 
            // cbSemestre
            // 
            this.cbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemestre.FormattingEnabled = true;
            this.cbSemestre.Items.AddRange(new object[] {
            "Primero",
            "Segundo"});
            this.cbSemestre.Location = new System.Drawing.Point(91, 36);
            this.cbSemestre.Name = "cbSemestre";
            this.cbSemestre.Size = new System.Drawing.Size(200, 21);
            this.cbSemestre.TabIndex = 2;
            // 
            // dgvCantidadFertMovido
            // 
            this.dgvCantidadFertMovido.AllowUserToAddRows = false;
            this.dgvCantidadFertMovido.AllowUserToDeleteRows = false;
            this.dgvCantidadFertMovido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCantidadFertMovido.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCantidadFertMovido.Location = new System.Drawing.Point(12, 63);
            this.dgvCantidadFertMovido.Name = "dgvCantidadFertMovido";
            this.dgvCantidadFertMovido.Size = new System.Drawing.Size(984, 607);
            this.dgvCantidadFertMovido.TabIndex = 3;
            this.dgvCantidadFertMovido.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(513, 676);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(852, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetFertilizanteMovido";
            reportDataSource1.Value = this.FertilizanteMovido_ClientesBindingSource;
            this.rvFertilizanteMovido.LocalReport.DataSources.Add(reportDataSource1);
            this.rvFertilizanteMovido.LocalReport.ReportEmbeddedResource = "Vista.ReporteFertilizanteMovido.rdlc";
            this.rvFertilizanteMovido.Location = new System.Drawing.Point(12, 63);
            this.rvFertilizanteMovido.Name = "reportViewer1";
            this.rvFertilizanteMovido.Size = new System.Drawing.Size(984, 607);
            this.rvFertilizanteMovido.TabIndex = 6;
            // 
            // FertilizanteMovido_ClientesTableAdapter
            // 
            this.FertilizanteMovido_ClientesTableAdapter.ClearBeforeFill = true;
            // 
            // frmInformeFertMovido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.rvFertilizanteMovido);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvCantidadFertMovido);
            this.Controls.Add(this.cbSemestre);
            this.Controls.Add(this.dtpAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmInformeFertMovido";
            this.Text = "Lista de los clientes que han movido más fertilizantes";
            this.Load += new System.EventHandler(this.frmInformeFertMovido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FertilizanteMovido_ClientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantidadFertMovido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAnio;
        private System.Windows.Forms.ComboBox cbSemestre;
        private System.Windows.Forms.DataGridView dgvCantidadFertMovido;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnActualizar;
        private Microsoft.Reporting.WinForms.ReportViewer rvFertilizanteMovido;
        private System.Windows.Forms.BindingSource FertilizanteMovido_ClientesBindingSource;
        private DataSetInformes DataSetInformes;
        private DataSetInformesTableAdapters.FertilizanteMovido_ClientesTableAdapter FertilizanteMovido_ClientesTableAdapter;
    }
}
namespace Vista
{
    partial class frmInformeVIP
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
            this.Mejores_ClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetInformes = new Vista.DataSetInformes();
            this.rvMejoresClientes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Mejores_ClientesTableAdapter = new Vista.DataSetInformesTableAdapters.Mejores_ClientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Mejores_ClientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformes)).BeginInit();
            this.SuspendLayout();
            // 
            // Mejores_ClientesBindingSource
            // 
            this.Mejores_ClientesBindingSource.DataMember = "Mejores_Clientes";
            this.Mejores_ClientesBindingSource.DataSource = this.DataSetInformes;
            // 
            // DataSetInformes
            // 
            this.DataSetInformes.DataSetName = "DataSetInformes";
            this.DataSetInformes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvMejoresClientes
            // 
            this.rvMejoresClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetMejoresClientes";
            reportDataSource1.Value = this.Mejores_ClientesBindingSource;
            this.rvMejoresClientes.LocalReport.DataSources.Add(reportDataSource1);
            this.rvMejoresClientes.LocalReport.ReportEmbeddedResource = "Vista.ReporteMejoresClientes.rdlc";
            this.rvMejoresClientes.Location = new System.Drawing.Point(0, 0);
            this.rvMejoresClientes.Name = "rvMejoresClientes";
            this.rvMejoresClientes.Size = new System.Drawing.Size(1008, 730);
            this.rvMejoresClientes.TabIndex = 0;
            // 
            // Mejores_ClientesTableAdapter
            // 
            this.Mejores_ClientesTableAdapter.ClearBeforeFill = true;
            // 
            // frmInformeVIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.rvMejoresClientes);
            this.Name = "frmInformeVIP";
            this.Text = "Clientes que más han movido fertilizantes";
            this.Load += new System.EventHandler(this.frmInformeVIP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mejores_ClientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvMejoresClientes;
        private System.Windows.Forms.BindingSource Mejores_ClientesBindingSource;
        private DataSetInformes DataSetInformes;
        private DataSetInformesTableAdapters.Mejores_ClientesTableAdapter Mejores_ClientesTableAdapter;
    }
}
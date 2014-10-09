namespace Vista
{
    partial class frmInformeEstadoAlquileres
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
            this.EstadoAlquileresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetInformes = new Vista.DataSetInformes();
            this.rvEstadoAlquileres = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EstadoAlquileresTableAdapter = new Vista.DataSetInformesTableAdapters.EstadoAlquileresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoAlquileresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformes)).BeginInit();
            this.SuspendLayout();
            // 
            // EstadoAlquileresBindingSource
            // 
            this.EstadoAlquileresBindingSource.DataMember = "EstadoAlquileres";
            this.EstadoAlquileresBindingSource.DataSource = this.DataSetInformes;
            // 
            // DataSetInformes
            // 
            this.DataSetInformes.DataSetName = "DataSetInformes";
            this.DataSetInformes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvEstadoAlquileres
            // 
            this.rvEstadoAlquileres.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetEstadoAlquileres";
            reportDataSource1.Value = this.EstadoAlquileresBindingSource;
            this.rvEstadoAlquileres.LocalReport.DataSources.Add(reportDataSource1);
            this.rvEstadoAlquileres.LocalReport.ReportEmbeddedResource = "Vista.ReporteEstadoAlquileres.rdlc";
            this.rvEstadoAlquileres.Location = new System.Drawing.Point(0, 0);
            this.rvEstadoAlquileres.Name = "rvEstadoAlquileres";
            this.rvEstadoAlquileres.Size = new System.Drawing.Size(1008, 730);
            this.rvEstadoAlquileres.TabIndex = 0;
            // 
            // EstadoAlquileresTableAdapter
            // 
            this.EstadoAlquileresTableAdapter.ClearBeforeFill = true;
            // 
            // frmInformeEstadoAlquileres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.rvEstadoAlquileres);
            this.Name = "frmInformeEstadoAlquileres";
            this.Text = "Estado de los alquileres";
            this.Load += new System.EventHandler(this.frmInformeEstadoAlquileres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EstadoAlquileresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvEstadoAlquileres;
        private System.Windows.Forms.BindingSource EstadoAlquileresBindingSource;
        private DataSetInformes DataSetInformes;
        private DataSetInformesTableAdapters.EstadoAlquileresTableAdapter EstadoAlquileresTableAdapter;
    }
}
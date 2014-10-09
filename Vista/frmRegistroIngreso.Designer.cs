namespace Vista
{
    partial class frmRegistroIngreso
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblNumMatricula = new System.Windows.Forms.Label();
            this.cbTipo_Matricula = new System.Windows.Forms.ComboBox();
            this.tbNum_Matricula = new System.Windows.Forms.TextBox();
            this.lblTipoMatricula = new System.Windows.Forms.Label();
            this.dgvTransportes = new System.Windows.Forms.DataGridView();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.cbPermiso = new System.Windows.Forms.ComboBox();
            this.tbNotas = new System.Windows.Forms.TextBox();
            this.lblPermiso = new System.Windows.Forms.Label();
            this.lblNotas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblChofer = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbChofer = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.lblNumMatricula);
            this.groupBox1.Controls.Add(this.cbTipo_Matricula);
            this.groupBox1.Controls.Add(this.tbNum_Matricula);
            this.groupBox1.Controls.Add(this.lblTipoMatricula);
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros - Transporte";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(679, 41);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 0;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lblNumMatricula
            // 
            this.lblNumMatricula.AutoSize = true;
            this.lblNumMatricula.Location = new System.Drawing.Point(8, 51);
            this.lblNumMatricula.Name = "lblNumMatricula";
            this.lblNumMatricula.Size = new System.Drawing.Size(110, 13);
            this.lblNumMatricula.TabIndex = 8;
            this.lblNumMatricula.Text = "Número de Matrícula:";
            // 
            // cbTipo_Matricula
            // 
            this.cbTipo_Matricula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo_Matricula.FormattingEnabled = true;
            this.cbTipo_Matricula.Items.AddRange(new object[] {
            "Patente"});
            this.cbTipo_Matricula.Location = new System.Drawing.Point(151, 19);
            this.cbTipo_Matricula.Name = "cbTipo_Matricula";
            this.cbTipo_Matricula.Size = new System.Drawing.Size(121, 21);
            this.cbTipo_Matricula.TabIndex = 6;
            // 
            // tbNum_Matricula
            // 
            this.tbNum_Matricula.Location = new System.Drawing.Point(151, 46);
            this.tbNum_Matricula.Name = "tbNum_Matricula";
            this.tbNum_Matricula.Size = new System.Drawing.Size(121, 20);
            this.tbNum_Matricula.TabIndex = 9;
            // 
            // lblTipoMatricula
            // 
            this.lblTipoMatricula.AutoSize = true;
            this.lblTipoMatricula.Location = new System.Drawing.Point(8, 22);
            this.lblTipoMatricula.Name = "lblTipoMatricula";
            this.lblTipoMatricula.Size = new System.Drawing.Size(94, 13);
            this.lblTipoMatricula.TabIndex = 7;
            this.lblTipoMatricula.Text = "Tipo de Matrícula:";
            // 
            // dgvTransportes
            // 
            this.dgvTransportes.AllowUserToAddRows = false;
            this.dgvTransportes.AllowUserToDeleteRows = false;
            this.dgvTransportes.AllowUserToOrderColumns = true;
            this.dgvTransportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransportes.Location = new System.Drawing.Point(12, 229);
            this.dgvTransportes.Name = "dgvTransportes";
            this.dgvTransportes.ReadOnly = true;
            this.dgvTransportes.Size = new System.Drawing.Size(760, 150);
            this.dgvTransportes.TabIndex = 1;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(12, 527);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // cbPermiso
            // 
            this.cbPermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPermiso.FormattingEnabled = true;
            this.cbPermiso.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cbPermiso.Location = new System.Drawing.Point(163, 478);
            this.cbPermiso.Name = "cbPermiso";
            this.cbPermiso.Size = new System.Drawing.Size(121, 21);
            this.cbPermiso.TabIndex = 3;
            // 
            // tbNotas
            // 
            this.tbNotas.Location = new System.Drawing.Point(163, 505);
            this.tbNotas.MaxLength = 320;
            this.tbNotas.Name = "tbNotas";
            this.tbNotas.Size = new System.Drawing.Size(500, 20);
            this.tbNotas.TabIndex = 4;
            // 
            // lblPermiso
            // 
            this.lblPermiso.AutoSize = true;
            this.lblPermiso.Location = new System.Drawing.Point(14, 481);
            this.lblPermiso.Name = "lblPermiso";
            this.lblPermiso.Size = new System.Drawing.Size(82, 13);
            this.lblPermiso.TabIndex = 5;
            this.lblPermiso.Text = "Permitir Ingreso:";
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Location = new System.Drawing.Point(14, 508);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(143, 13);
            this.lblNotas.TabIndex = 6;
            this.lblNotas.Text = "Notas/Razones del rechazo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo de operación:";
            // 
            // cbTipoOperacion
            // 
            this.cbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoOperacion.FormattingEnabled = true;
            this.cbTipoOperacion.Items.AddRange(new object[] {
            "Carga",
            "Descarga"});
            this.cbTipoOperacion.Location = new System.Drawing.Point(163, 451);
            this.cbTipoOperacion.Name = "cbTipoOperacion";
            this.cbTipoOperacion.Size = new System.Drawing.Size(121, 21);
            this.cbTipoOperacion.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(697, 527);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cliente:";
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(20, 79);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(38, 13);
            this.lblChofer.TabIndex = 9;
            this.lblChofer.Text = "Chofer";
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(163, 49);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(121, 21);
            this.cbCliente.TabIndex = 10;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // cbChofer
            // 
            this.cbChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChofer.FormattingEnabled = true;
            this.cbChofer.Location = new System.Drawing.Point(163, 76);
            this.cbChofer.Name = "cbChofer";
            this.cbChofer.Size = new System.Drawing.Size(121, 21);
            this.cbChofer.TabIndex = 11;
            this.cbChofer.SelectedIndexChanged += new System.EventHandler(this.cbChofer_SelectedIndexChanged);
            // 
            // frmRegistroIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.cbChofer);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lblChofer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.lblPermiso);
            this.Controls.Add(this.tbNotas);
            this.Controls.Add(this.cbTipoOperacion);
            this.Controls.Add(this.cbPermiso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dgvTransportes);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRegistroIngreso";
            this.Text = "Registro de Ingresos";
            this.Load += new System.EventHandler(this.frmRegistroIngreso_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblNumMatricula;
        private System.Windows.Forms.ComboBox cbTipo_Matricula;
        private System.Windows.Forms.TextBox tbNum_Matricula;
        private System.Windows.Forms.Label lblTipoMatricula;
        private System.Windows.Forms.DataGridView dgvTransportes;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ComboBox cbPermiso;
        private System.Windows.Forms.TextBox tbNotas;
        private System.Windows.Forms.Label lblPermiso;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipoOperacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.ComboBox cbChofer;
    }
}
namespace Vista
{
    partial class frmPrincipal
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
            this.msMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnEquivalencias = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCambiar_Clave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAlmacenes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChoferes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTransportes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAlquileres = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReg_Ingreso = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutorizaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCargaYDescarga = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGrupos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMovimientos = new System.Windows.Forms.Button();
            this.btnEquivalentes = new System.Windows.Forms.Button();
            this.btnEstadoAlquileres = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAutorizacion = new System.Windows.Forms.Button();
            this.btnCargaDescarga = new System.Windows.Forms.Button();
            this.btnRegistroIngreso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMenuPrincipal
            // 
            this.msMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msMenuPrincipal.Name = "msMenuPrincipal";
            this.msMenuPrincipal.Size = new System.Drawing.Size(1008, 24);
            this.msMenuPrincipal.TabIndex = 2;
            this.msMenuPrincipal.Text = "menuStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(12, 698);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(76, 23);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario:";
            // 
            // btnEquivalencias
            // 
            this.btnEquivalencias.Name = "btnEquivalencias";
            this.btnEquivalencias.Size = new System.Drawing.Size(152, 22);
            this.btnEquivalencias.Text = "Equivalencias";
            this.btnEquivalencias.Click += new System.EventHandler(this.btnEquivalencias_Click);
            // 
            // btnCambiar_Clave
            // 
            this.btnCambiar_Clave.Name = "btnCambiar_Clave";
            this.btnCambiar_Clave.Size = new System.Drawing.Size(152, 22);
            this.btnCambiar_Clave.Text = "Cambiar Clave";
            this.btnCambiar_Clave.Click += new System.EventHandler(this.btnRec_Clave_Click);
            // 
            // btnAlmacenes
            // 
            this.btnAlmacenes.Name = "btnAlmacenes";
            this.btnAlmacenes.Size = new System.Drawing.Size(152, 22);
            this.btnAlmacenes.Text = "Almacenes";
            this.btnAlmacenes.Visible = false;
            this.btnAlmacenes.Click += new System.EventHandler(this.btnAlmacenes_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(152, 22);
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Visible = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnChoferes
            // 
            this.btnChoferes.Name = "btnChoferes";
            this.btnChoferes.Size = new System.Drawing.Size(152, 22);
            this.btnChoferes.Text = "Choferes";
            this.btnChoferes.Visible = false;
            this.btnChoferes.Click += new System.EventHandler(this.btnChoferes_Click);
            // 
            // btnTransportes
            // 
            this.btnTransportes.Name = "btnTransportes";
            this.btnTransportes.Size = new System.Drawing.Size(152, 22);
            this.btnTransportes.Text = "Transportes";
            this.btnTransportes.Visible = false;
            this.btnTransportes.Click += new System.EventHandler(this.btnTransportes_Click);
            // 
            // btnAlquileres
            // 
            this.btnAlquileres.Name = "btnAlquileres";
            this.btnAlquileres.Size = new System.Drawing.Size(152, 22);
            this.btnAlquileres.Text = "Alquileres";
            this.btnAlquileres.Visible = false;
            this.btnAlquileres.Click += new System.EventHandler(this.btnAlquileres_Click);
            // 
            // btnReg_Ingreso
            // 
            this.btnReg_Ingreso.Name = "btnReg_Ingreso";
            this.btnReg_Ingreso.Size = new System.Drawing.Size(175, 22);
            this.btnReg_Ingreso.Text = "Registro de Ingreso";
            this.btnReg_Ingreso.Visible = false;
            this.btnReg_Ingreso.Click += new System.EventHandler(this.btnReg_Ingreso_Click);
            // 
            // btnAutorizaciones
            // 
            this.btnAutorizaciones.Name = "btnAutorizaciones";
            this.btnAutorizaciones.Size = new System.Drawing.Size(175, 22);
            this.btnAutorizaciones.Text = "Autorizaciones";
            this.btnAutorizaciones.Visible = false;
            this.btnAutorizaciones.Click += new System.EventHandler(this.btnAutorizaciones_Click);
            // 
            // btnCargaYDescarga
            // 
            this.btnCargaYDescarga.Name = "btnCargaYDescarga";
            this.btnCargaYDescarga.Size = new System.Drawing.Size(175, 22);
            this.btnCargaYDescarga.Text = "Carga y Descarga";
            this.btnCargaYDescarga.Click += new System.EventHandler(this.btnCargaYDescarga_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(119, 22);
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Visible = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnPerfiles
            // 
            this.btnPerfiles.Name = "btnPerfiles";
            this.btnPerfiles.Size = new System.Drawing.Size(119, 22);
            this.btnPerfiles.Text = "Perfiles";
            this.btnPerfiles.Visible = false;
            this.btnPerfiles.Click += new System.EventHandler(this.btnPerfiles_Click);
            // 
            // btnGrupos
            // 
            this.btnGrupos.Name = "btnGrupos";
            this.btnGrupos.Size = new System.Drawing.Size(119, 22);
            this.btnGrupos.Text = "Grupos";
            this.btnGrupos.Visible = false;
            this.btnGrupos.Click += new System.EventHandler(this.btnGrupos_Click);
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMovimientos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMovimientos.BackColor = System.Drawing.Color.Transparent;
            this.btnMovimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMovimientos.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovimientos.ForeColor = System.Drawing.Color.Black;
            this.btnMovimientos.Image = global::Vista.Properties.Resources.movimientos;
            this.btnMovimientos.Location = new System.Drawing.Point(781, 354);
            this.btnMovimientos.Margin = new System.Windows.Forms.Padding(0);
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(184, 163);
            this.btnMovimientos.TabIndex = 10;
            this.btnMovimientos.Text = "Movimientos";
            this.btnMovimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMovimientos.UseVisualStyleBackColor = false;
            this.btnMovimientos.Click += new System.EventHandler(this.btnMovimientos_Click);
            // 
            // btnEquivalentes
            // 
            this.btnEquivalentes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEquivalentes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEquivalentes.BackColor = System.Drawing.Color.Transparent;
            this.btnEquivalentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEquivalentes.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquivalentes.ForeColor = System.Drawing.Color.Black;
            this.btnEquivalentes.Image = global::Vista.Properties.Resources.calculadora;
            this.btnEquivalentes.Location = new System.Drawing.Point(567, 354);
            this.btnEquivalentes.Margin = new System.Windows.Forms.Padding(0);
            this.btnEquivalentes.Name = "btnEquivalentes";
            this.btnEquivalentes.Size = new System.Drawing.Size(184, 163);
            this.btnEquivalentes.TabIndex = 9;
            this.btnEquivalentes.Text = "Equivalentes";
            this.btnEquivalentes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEquivalentes.UseVisualStyleBackColor = false;
            this.btnEquivalentes.Click += new System.EventHandler(this.btnEquivalentes_Click);
            // 
            // btnEstadoAlquileres
            // 
            this.btnEstadoAlquileres.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEstadoAlquileres.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEstadoAlquileres.BackColor = System.Drawing.Color.Transparent;
            this.btnEstadoAlquileres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoAlquileres.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadoAlquileres.ForeColor = System.Drawing.Color.Black;
            this.btnEstadoAlquileres.Image = global::Vista.Properties.Resources.estadoalquiler;
            this.btnEstadoAlquileres.Location = new System.Drawing.Point(350, 354);
            this.btnEstadoAlquileres.Margin = new System.Windows.Forms.Padding(0);
            this.btnEstadoAlquileres.Name = "btnEstadoAlquileres";
            this.btnEstadoAlquileres.Size = new System.Drawing.Size(184, 163);
            this.btnEstadoAlquileres.TabIndex = 8;
            this.btnEstadoAlquileres.Text = "Estado de Alquileres";
            this.btnEstadoAlquileres.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEstadoAlquileres.UseVisualStyleBackColor = false;
            this.btnEstadoAlquileres.Click += new System.EventHandler(this.btnEstadoAlquileres_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Vista.Properties.Resources.Sin_título_1;
            this.pictureBox1.Location = new System.Drawing.Point(752, 612);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 120);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnAutorizacion
            // 
            this.btnAutorizacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAutorizacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAutorizacion.BackColor = System.Drawing.Color.Transparent;
            this.btnAutorizacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutorizacion.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutorizacion.ForeColor = System.Drawing.Color.Black;
            this.btnAutorizacion.Image = global::Vista.Properties.Resources.autorizacion;
            this.btnAutorizacion.Location = new System.Drawing.Point(781, 166);
            this.btnAutorizacion.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutorizacion.Name = "btnAutorizacion";
            this.btnAutorizacion.Size = new System.Drawing.Size(184, 163);
            this.btnAutorizacion.TabIndex = 6;
            this.btnAutorizacion.Text = "Autorización";
            this.btnAutorizacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAutorizacion.UseVisualStyleBackColor = false;
            this.btnAutorizacion.Click += new System.EventHandler(this.btnAutorizacion_Click);
            // 
            // btnCargaDescarga
            // 
            this.btnCargaDescarga.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCargaDescarga.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCargaDescarga.BackColor = System.Drawing.Color.Transparent;
            this.btnCargaDescarga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargaDescarga.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargaDescarga.ForeColor = System.Drawing.Color.Black;
            this.btnCargaDescarga.Image = global::Vista.Properties.Resources.cargadescarga;
            this.btnCargaDescarga.Location = new System.Drawing.Point(567, 166);
            this.btnCargaDescarga.Margin = new System.Windows.Forms.Padding(0);
            this.btnCargaDescarga.Name = "btnCargaDescarga";
            this.btnCargaDescarga.Size = new System.Drawing.Size(184, 163);
            this.btnCargaDescarga.TabIndex = 5;
            this.btnCargaDescarga.Text = "Carga | Descarga";
            this.btnCargaDescarga.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCargaDescarga.UseVisualStyleBackColor = false;
            this.btnCargaDescarga.Click += new System.EventHandler(this.btnCargaDescarga_Click);
            // 
            // btnRegistroIngreso
            // 
            this.btnRegistroIngreso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRegistroIngreso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegistroIngreso.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistroIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistroIngreso.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroIngreso.ForeColor = System.Drawing.Color.Black;
            this.btnRegistroIngreso.Image = global::Vista.Properties.Resources.ingreso;
            this.btnRegistroIngreso.Location = new System.Drawing.Point(350, 166);
            this.btnRegistroIngreso.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegistroIngreso.Name = "btnRegistroIngreso";
            this.btnRegistroIngreso.Size = new System.Drawing.Size(184, 163);
            this.btnRegistroIngreso.TabIndex = 4;
            this.btnRegistroIngreso.Text = "Registrar Ingreso";
            this.btnRegistroIngreso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRegistroIngreso.UseVisualStyleBackColor = false;
            this.btnRegistroIngreso.Click += new System.EventHandler(this.btnRegistroIngreso_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btnMovimientos);
            this.Controls.Add(this.btnEquivalentes);
            this.Controls.Add(this.btnEstadoAlquileres);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAutorizacion);
            this.Controls.Add(this.btnCargaDescarga);
            this.Controls.Add(this.btnRegistroIngreso);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.msMenuPrincipal);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenuPrincipal;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem btnEquivalencias;
        private System.Windows.Forms.ToolStripMenuItem btnCambiar_Clave;
        private System.Windows.Forms.ToolStripMenuItem btnAlmacenes;
        private System.Windows.Forms.ToolStripMenuItem btnClientes;
        private System.Windows.Forms.ToolStripMenuItem btnChoferes;
        private System.Windows.Forms.ToolStripMenuItem btnTransportes;
        private System.Windows.Forms.ToolStripMenuItem btnAlquileres;
        private System.Windows.Forms.ToolStripMenuItem btnReg_Ingreso;
        private System.Windows.Forms.ToolStripMenuItem btnAutorizaciones;
        private System.Windows.Forms.ToolStripMenuItem btnCargaYDescarga;
        private System.Windows.Forms.ToolStripMenuItem btnUsuarios;
        private System.Windows.Forms.ToolStripMenuItem btnPerfiles;
        private System.Windows.Forms.ToolStripMenuItem btnGrupos;
        private System.Windows.Forms.Button btnRegistroIngreso;
        private System.Windows.Forms.Button btnCargaDescarga;
        private System.Windows.Forms.Button btnAutorizacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEstadoAlquileres;
        private System.Windows.Forms.Button btnEquivalentes;
        private System.Windows.Forms.Button btnMovimientos;

    }
}
namespace Vista
{
    partial class frmPrincipalAntiguo
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
            this.btnMenuGestiones = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAlmacenes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChoferes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTransportes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAlquileres = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuAutorizaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReg_Ingreso = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutorizaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCargaYDescarga = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGrupos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCambiar_Clave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEquivalencias = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.msMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenuPrincipal
            // 
            this.msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuGestiones,
            this.btnMenuAutorizaciones,
            this.btnMenuSeguridad,
            this.btnMenuUsuario,
            this.btnHerramientas});
            this.msMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msMenuPrincipal.Name = "msMenuPrincipal";
            this.msMenuPrincipal.Size = new System.Drawing.Size(594, 24);
            this.msMenuPrincipal.TabIndex = 2;
            this.msMenuPrincipal.Text = "menuStrip1";
            // 
            // btnMenuGestiones
            // 
            this.btnMenuGestiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAlmacenes,
            this.btnClientes,
            this.btnChoferes,
            this.btnTransportes,
            this.btnAlquileres});
            this.btnMenuGestiones.Enabled = false;
            this.btnMenuGestiones.Name = "btnMenuGestiones";
            this.btnMenuGestiones.Size = new System.Drawing.Size(70, 20);
            this.btnMenuGestiones.Text = "Gestiones";
            this.btnMenuGestiones.Visible = false;
            // 
            // btnAlmacenes
            // 
            this.btnAlmacenes.Name = "btnAlmacenes";
            this.btnAlmacenes.Size = new System.Drawing.Size(136, 22);
            this.btnAlmacenes.Text = "Almacenes";
            this.btnAlmacenes.Visible = false;
            this.btnAlmacenes.Click += new System.EventHandler(this.btnAlmacenes_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(136, 22);
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Visible = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnChoferes
            // 
            this.btnChoferes.Name = "btnChoferes";
            this.btnChoferes.Size = new System.Drawing.Size(136, 22);
            this.btnChoferes.Text = "Choferes";
            this.btnChoferes.Visible = false;
            this.btnChoferes.Click += new System.EventHandler(this.btnChoferes_Click);
            // 
            // btnTransportes
            // 
            this.btnTransportes.Name = "btnTransportes";
            this.btnTransportes.Size = new System.Drawing.Size(136, 22);
            this.btnTransportes.Text = "Transportes";
            this.btnTransportes.Visible = false;
            this.btnTransportes.Click += new System.EventHandler(this.btnTransportes_Click);
            // 
            // btnAlquileres
            // 
            this.btnAlquileres.Name = "btnAlquileres";
            this.btnAlquileres.Size = new System.Drawing.Size(136, 22);
            this.btnAlquileres.Text = "Alquileres";
            this.btnAlquileres.Visible = false;
            this.btnAlquileres.Click += new System.EventHandler(this.btnAlquileres_Click);
            // 
            // btnMenuAutorizaciones
            // 
            this.btnMenuAutorizaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReg_Ingreso,
            this.btnAutorizaciones,
            this.btnCargaYDescarga});
            this.btnMenuAutorizaciones.Enabled = false;
            this.btnMenuAutorizaciones.Name = "btnMenuAutorizaciones";
            this.btnMenuAutorizaciones.Size = new System.Drawing.Size(97, 20);
            this.btnMenuAutorizaciones.Text = "Autorizaciones";
            this.btnMenuAutorizaciones.Visible = false;
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
            // btnMenuSeguridad
            // 
            this.btnMenuSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUsuarios,
            this.btnPerfiles,
            this.btnGrupos});
            this.btnMenuSeguridad.Enabled = false;
            this.btnMenuSeguridad.Name = "btnMenuSeguridad";
            this.btnMenuSeguridad.Size = new System.Drawing.Size(72, 20);
            this.btnMenuSeguridad.Text = "Seguridad";
            this.btnMenuSeguridad.Visible = false;
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
            // btnMenuUsuario
            // 
            this.btnMenuUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCambiar_Clave});
            this.btnMenuUsuario.Name = "btnMenuUsuario";
            this.btnMenuUsuario.Size = new System.Drawing.Size(59, 20);
            this.btnMenuUsuario.Text = "Usuario";
            // 
            // btnCambiar_Clave
            // 
            this.btnCambiar_Clave.Name = "btnCambiar_Clave";
            this.btnCambiar_Clave.Size = new System.Drawing.Size(151, 22);
            this.btnCambiar_Clave.Text = "Cambiar Clave";
            this.btnCambiar_Clave.Click += new System.EventHandler(this.btnRec_Clave_Click);
            // 
            // btnHerramientas
            // 
            this.btnHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEquivalencias});
            this.btnHerramientas.Name = "btnHerramientas";
            this.btnHerramientas.Size = new System.Drawing.Size(90, 20);
            this.btnHerramientas.Text = "Herramientas";
            // 
            // btnEquivalencias
            // 
            this.btnEquivalencias.Name = "btnEquivalencias";
            this.btnEquivalencias.Size = new System.Drawing.Size(145, 22);
            this.btnEquivalencias.Text = "Equivalencias";
            this.btnEquivalencias.Click += new System.EventHandler(this.btnEquivalencias_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 240);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario:";
            // 
            // frmPrincipalAntiguo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 262);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.msMenuPrincipal);
            this.Name = "frmPrincipalAntiguo";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.frmPrincipalAntiguo_Load);
            this.msMenuPrincipal.ResumeLayout(false);
            this.msMenuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem btnMenuGestiones;
        private System.Windows.Forms.ToolStripMenuItem btnAlmacenes;
        private System.Windows.Forms.ToolStripMenuItem btnClientes;
        private System.Windows.Forms.ToolStripMenuItem btnChoferes;
        private System.Windows.Forms.ToolStripMenuItem btnTransportes;
        private System.Windows.Forms.ToolStripMenuItem btnAlquileres;
        private System.Windows.Forms.ToolStripMenuItem btnMenuAutorizaciones;
        private System.Windows.Forms.ToolStripMenuItem btnReg_Ingreso;
        private System.Windows.Forms.ToolStripMenuItem btnAutorizaciones;
        private System.Windows.Forms.ToolStripMenuItem btnMenuSeguridad;
        private System.Windows.Forms.ToolStripMenuItem btnUsuarios;
        private System.Windows.Forms.ToolStripMenuItem btnPerfiles;
        private System.Windows.Forms.ToolStripMenuItem btnGrupos;
        private System.Windows.Forms.ToolStripMenuItem btnMenuUsuario;
        private System.Windows.Forms.ToolStripMenuItem btnCambiar_Clave;
        private System.Windows.Forms.ToolStripMenuItem btnCargaYDescarga;
        private System.Windows.Forms.ToolStripMenuItem btnHerramientas;
        private System.Windows.Forms.ToolStripMenuItem btnEquivalencias;
        private System.Windows.Forms.Label lblUsuario;

    }
}
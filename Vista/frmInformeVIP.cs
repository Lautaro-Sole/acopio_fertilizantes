using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Vista
{
    public partial class frmInformeVIP : Form
    {
        private static frmInformeVIP Instancia;
        private Modelo_Entidades.USUARIO oUsuarioActual;
        private frmInformeVIP()
        {
            InitializeComponent();
        }
        public static frmInformeVIP ObtenerInstancia(Modelo_Entidades.USUARIO oUsuario)
         {
             if (Instancia == null || Instancia.IsDisposed == true)
                 Instancia = new frmInformeVIP(oUsuario);
             return Instancia;
         }

        private frmInformeVIP(Modelo_Entidades.USUARIO oUsuario)
        {
            InitializeComponent();
            oUsuarioActual = oUsuario;
            this.rvMejoresClientes.ProcessingMode = ProcessingMode.Local;
            this.Mejores_ClientesTableAdapter.ClearBeforeFill = true;
            this.Mejores_ClientesTableAdapter.Fill(this.DataSetInformes.Mejores_Clientes, 10);

        }

        private void frmInformeVIP_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetInformes.Mejores_Clientes' Puede moverla o quitarla según sea necesario.
            //this.Mejores_ClientesTableAdapter.Fill(this.DataSetInformes.Mejores_Clientes);

            this.rvMejoresClientes.RefreshReport();
        }
    }
}

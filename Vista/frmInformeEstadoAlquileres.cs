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
    public partial class frmInformeEstadoAlquileres : Form
    {
        private static frmInformeEstadoAlquileres Instancia;
        private Modelo_Entidades.USUARIO oUsuarioActual;
        private frmInformeEstadoAlquileres()
        {
            InitializeComponent();
        }
        public static frmInformeEstadoAlquileres ObtenerInstancia(Modelo_Entidades.USUARIO oUsuario)
         {
             if (Instancia == null || Instancia.IsDisposed == true)
                 Instancia = new frmInformeEstadoAlquileres(oUsuario);
             return Instancia;
         }

        private frmInformeEstadoAlquileres(Modelo_Entidades.USUARIO oUsuario)
        {
            InitializeComponent();
            oUsuarioActual = oUsuario;
            this.rvEstadoAlquileres.ProcessingMode = ProcessingMode.Local;
            this.EstadoAlquileresTableAdapter.ClearBeforeFill = true;
            this.EstadoAlquileresTableAdapter.Fill(this.DataSetInformes.EstadoAlquileres, 10);

        }

        private void frmInformeEstadoAlquileres_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetInformes.EstadoAlquileres' Puede moverla o quitarla según sea necesario.
            //this.EstadoAlquileresTableAdapter.Fill(this.DataSetInformes.EstadoAlquileres);

            this.rvEstadoAlquileres.RefreshReport();
        }
    }
}

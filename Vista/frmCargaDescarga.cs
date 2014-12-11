using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmCargaDescarga : Form
    {
        BindingSource bsAlquileres = new BindingSource();
        Controladora.CCUGAlquileres oCCUGAlquileres = new Controladora.CCUGAlquileres();
        Controladora.CCUCore oCCUCore = Controladora.CCUCore.ObtenerInstancia();
        Modelo_Entidades.Operacion oOperacion;
        
        Modelo_Entidades.USUARIO oUsuarioActual;
        private static frmCargaDescarga Instancia;
        private frmCargaDescarga(Modelo_Entidades.USUARIO oUsu, Modelo_Entidades.Operacion oOperacionEnviado)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
            oOperacion = oOperacionEnviado;
            //oOperacion = oOperacionEnviado;
        }
        public static frmCargaDescarga ObtenerInstancia(Modelo_Entidades.USUARIO oUsu, Modelo_Entidades.Operacion oOperacionEnviado)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmCargaDescarga(oUsu, oOperacionEnviado);
            return Instancia;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.msktbPesoInicial.Text))
            {
                this.msktbPesoInicial.Focus();
                MessageBox.Show("Primero debe ingresar el peso inicial.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbPesoFinal.Text))
            {
                this.msktbPesoFinal.Focus();
                MessageBox.Show("Primero debe ingresar el peso final.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            /*
            if (string.IsNullOrEmpty(this.msktbTara.Text))
            {
                this.msktbPesoInicial.Focus();
                MessageBox.Show("Primero debe ingresar la tara.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
             * */
            if (oOperacion.tipo_operacion == "Descarga")
            {
                //si la operacion es una descarga el peso final no debe ser mayor que que el inicial
                if (Convert.ToInt32(this.msktbPesoFinal.Text) >= Convert.ToInt32(this.msktbPesoInicial.Text))
                {
                    MessageBox.Show("El peso final no puede ser mayor o igual que el peso inicial.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                //si la operacion es una carga el peso final no debe ser menor que que el inicial
                if (Convert.ToInt32(this.msktbPesoFinal.Text) <= Convert.ToInt32(this.msktbPesoInicial.Text))
                {
                    MessageBox.Show("El peso final no puede ser menor o igual que el peso inicial.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            int _peso = Convert.ToInt32(this.msktbPesoFinal.Text) - Convert.ToInt32(this.msktbPesoInicial.Text);
            //si lo entregado está dentro de la tolerancia -> movido a la clase
            /*
            if (!((oOperacion.Documentos.peso * 0.95 <= _peso) & (_peso <= oOperacion.Documentos.peso * 1.05)))
            {
                MessageBox.Show("La diferencia entre el peso en la orden de carga y la cargada realmente está fuera de la tolerancia establecida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                oOperacion.peso_inicial = Convert.ToSingle(this.msktbPesoInicial.Text);
                oOperacion.peso_final = Convert.ToSingle(this.msktbPesoFinal.Text);
                oOperacion.notas = this.tbNotas.Text;
                oOperacion.estado = "Finalizado";


                //datos auditoría
                oOperacion.USU_CODIGO = oUsuarioActual.USU_CODIGO;
                oOperacion.fecha_y_hora_accion = DateTime.Now;
                oOperacion.accion = "Modificacion - Registrar " + oOperacion.tipo_operacion;


                try
                {
                    //bool resultado = oCCUGAlquileres.Modificacion(oOperacion.Alquileres);

                    //llamar comprobacion (comprobar si lo movido concuerda con lo que está en el documento)
                    bool resultado = oCCUCore.ComprobarFertilizanteMovido(oOperacion);

                    if (resultado)
                    {
                        //actualizar los valores del alquiler
                        oCCUCore.ActualizarAlquiler(oOperacion);

                        bool resultado2 = oCCUCore.Modificar(oOperacion);
                        if (resultado2)
                        {
                            MessageBox.Show(this.oOperacion.tipo_operacion + " registrada correctamente.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmCargaYDescarga.ObtenerInstancia(oUsuarioActual).ActualizarDGVOperaciones();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this.oOperacion.tipo_operacion + " no registrada.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this.oOperacion.tipo_operacion + " no registrada.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Data.DataException ex)
                {
                    MessageBox.Show("Excepcion: " + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void frmCargaDescarga_Load(object sender, EventArgs e)
        {
            this.tbNotas.Text = oOperacion.notas;
            this.Text = "Registrar " + oOperacion.tipo_operacion;
            if (oOperacion.tipo_operacion=="Carga")
            {
                oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaCarga());
            }
            else
            {
                oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaDescarga());
            }
        }


    }
}

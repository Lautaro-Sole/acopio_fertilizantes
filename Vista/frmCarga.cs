﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmCarga : Form
    {
        BindingSource bsAlquileres = new BindingSource();
        Controladora.CCUGAlquileres oCCUGAlquileres = Controladora.CCUGAlquileres.ObtenerInstancia();
        Controladora.CCUCore oCCUCore = Controladora.CCUCore.ObtenerInstancia();
        Modelo_Entidades.Operacion oOperacion;
        
        Modelo_Entidades.USUARIO oUsuarioActual;
        private static frmCarga Instancia;
        private frmCarga(Modelo_Entidades.USUARIO oUsu, Modelo_Entidades.Operacion oOperacionEnviado)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
            oOperacion = oOperacionEnviado;
            //oOperacion = oOperacionEnviado;
        }
        public static frmCarga ObtenerInstancia(Modelo_Entidades.USUARIO oUsu, Modelo_Entidades.Operacion oOperacionEnviado)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmCarga(oUsu, oOperacionEnviado);
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
            if (Convert.ToInt32(this.msktbPesoFinal.Text) <= Convert.ToInt32(this.msktbPesoInicial.Text))
            {
                MessageBox.Show("El peso final no puede ser menor o igual que el peso inicial.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                int _peso = Convert.ToInt32(this.msktbPesoFinal.Text) - Convert.ToInt32(this.msktbPesoInicial.Text);
                //si lo entregado está dentro de la tolerancia
                if ((oOperacion.Documento.peso * 0.95 <= _peso) & (_peso <= oOperacion.Documento.peso * 1.05))
                {
                    /*
                    //calcular la superficie liberada en el alquiler por la carga
                    int _superficieliberada = oCCUCore.ConvertirKGaM2(_peso);
                    //agregar a la superficie no utilizada la liberada por la carga
                    oOperacion.Alquileres.superficie_no_utilizada += _superficieliberada;
                     * */
                    try
                    {
                        bool resultado = oCCUGAlquileres.Modificar(oOperacion.Alquiler);
                        if (resultado)
                        {
                            bool resultado2 = oCCUCore.Modificar(oOperacion);
                            if (resultado2)
                            {
                                MessageBox.Show("Carga registrada correctamente.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmCargaYDescarga.ObtenerInstancia(oUsuarioActual).ActualizarDGVOperaciones();
                            }
                            else
                            {
                                MessageBox.Show("Carga no registrada.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Carga no registrada.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (System.Data.DataException ex)
                    {
                        MessageBox.Show("Excepcion: " + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La diferencia entre el peso en la orden de carga y la cargada realmente está fuera de la tolerancia establecida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmCarga_Load(object sender, EventArgs e)
        {
            this.tbNotas.Text = oOperacion.notas;
        }


    }
}

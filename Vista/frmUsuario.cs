using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmUsuario : Form
    {
        string Modo;
        Modelo_Entidades.GRUPO oGrupo;
        Modelo_Entidades.USUARIO oUsuario;
        Controladora.CCUGGrupos oCCUGGrupos = new Controladora.CCUGGrupos();
        Controladora.CCUGUsuarios oCCUGUsuarios = new Controladora.CCUGUsuarios();
        BindingSource bsGrupos = new BindingSource();
        public frmUsuario()
        {
            InitializeComponent();
            Modo = "Alta";
        }
        public frmUsuario(Modelo_Entidades.USUARIO oUsuarioEnviado)
        {
            InitializeComponent();
            Modo = "Modificacion";
            oUsuario = oUsuarioEnviado;
        }

        private bool validarObligatorios()
        {
            if (string.IsNullOrEmpty(this.tbUsuario.Text))
            {
                this.tbUsuario.Focus();
                MessageBox.Show("Primero debe ingresar el usuario.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbApellido.Text))
            {
                this.tbApellido.Focus();
                MessageBox.Show("Primero debe ingresar el apellido del usuario.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbNombre.Text))
            {
                this.tbNombre.Focus();
                MessageBox.Show("Primero debe elegir el nombre del usuario.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbEMail.Text))
            {
                this.tbEMail.Focus();
                MessageBox.Show("Primero debe escribir el E-Mail del usuario.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string expresionregular = @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$";
            if (!(Regex.IsMatch(this.tbEMail.Text, expresionregular))) //si el mail no concuerda con la expresion regular
            {
                this.tbEMail.Focus();
                MessageBox.Show("El E-Mail ingresado tiene un formato incorrecto.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (clbGrupos.CheckedItems.Count<=0) // al menos un grupo
            {
                MessageBox.Show("Primero debe seleccionar al menos un grupo.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }  
            else return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Modo == "Alta")
            {
                if (validarObligatorios())
                {
                    oUsuario = new Modelo_Entidades.USUARIO();
                    oUsuario.USU_APELLIDO = this.tbApellido.Text;
                    oUsuario.USU_CODIGO = this.tbUsuario.Text;
                    oUsuario.USU_EMAIL = this.tbEMail.Text;
                    oUsuario.USU_ESTADO = this.cbEstado.Checked;
                    oUsuario.USU_NOMBRE = this.tbNombre.Text;
                    //vacío la colección de grupos del usuario, para que al quitar uno no quede guardado desde antes
                    oUsuario.GRUPOS.Clear();
                    //agregar todos los grupos checkeados a la lista de grupos
                    foreach (object item in clbGrupos.CheckedItems)//por cada objeto "item" de la lista de objetos checkeados en clbgrupos
                    {
                        oUsuario.GRUPOS.Add((Modelo_Entidades.GRUPO)item);//agrego el item, después de transformarlo en grupo, a la colección
                    }
                    if (this.cbEstado.Checked == true)
                    {
                        oUsuario.USU_ESTADO = true;
                    }
                    else
                    {
                        oUsuario.USU_ESTADO = false;
                    }

                    bool resultado;
                    try
                    {
                        Modelo_Entidades.USUARIO oUsuarioEncontrado = oCCUGUsuarios.ObtenerUsuario(oUsuario.USU_CODIGO);
                        if (oUsuarioEncontrado != null)
                        {
                            MessageBox.Show("El usuario ya existe.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        resultado = oCCUGUsuarios.Agregar(oUsuario);
                        if (resultado)
                        {
                            MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmUsuarios.ObtenerInstancia().cargarGrillaUsuarios();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (System.Data.EntitySqlException ex)
                    {
                        MessageBox.Show("No se ha podido guardar el nuevo usuario: " + ex.InnerException.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (validarObligatorios())
                {
                    oUsuario.USU_APELLIDO = this.tbApellido.Text;
                    oUsuario.USU_CODIGO = this.tbUsuario.Text;
                    oUsuario.USU_EMAIL = this.tbEMail.Text;
                    oUsuario.USU_ESTADO = this.cbEstado.Checked;
                    oUsuario.USU_NOMBRE = this.tbNombre.Text;
                    //vacío la colección de grupos del usuario, para que al quitar uno no quede guardado desde antes
                    oUsuario.GRUPOS.Clear();
                    //agregar los grupos checkeados que no estén todavía en la lista de grupos a la misma
                    foreach (object item in clbGrupos.CheckedItems)//por cada objeto "item" de la lista de objetos checkeados en clbgrupos
                    {
                        oGrupo = (Modelo_Entidades.GRUPO)item; //convierto el item en un grupo (oGrupo)
                        Modelo_Entidades.GRUPO oGrupoEncontrado; //declaro el grupo oGrupoEncontrado
                        //busco en la lista de grupos del usuario el grupo cuyo código sea igual al código del grupo actual, oGrupo
                        oGrupoEncontrado = oUsuario.GRUPOS.ToList<Modelo_Entidades.GRUPO>().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscado) { return oGrupoBuscado.GRU_CODIGO == oGrupo.GRU_CODIGO; });
                        if (oGrupoEncontrado == null) //si el grupo encontrado es nulo (significa que el que busqué todavía no fue agregado)
                        {
                            oUsuario.GRUPOS.Add(oGrupo);//agrego el grupo encontrado a la colección
                        }
                    }
                    if (this.cbEstado.Checked == true)
                    {
                        oGrupo.GRU_ESTADO = true;
                    }
                    else
                    {
                        oGrupo.GRU_ESTADO = false;
                    }
                    bool resultado;
                    try
                    {
                        resultado = oCCUGUsuarios.Modificar(oUsuario);
                        if (resultado)
                        {
                            MessageBox.Show("Actualizado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmUsuarios.ObtenerInstancia().cargarGrillaUsuarios();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No actualizado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (System.Data.EntitySqlException ex)
                    {
                        MessageBox.Show("No se ha podido actualizar el usuario: " + ex.InnerException.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            bsGrupos.DataSource=oCCUGGrupos.ObtenerGrupos();
            foreach (Modelo_Entidades.GRUPO oGrupo in bsGrupos) //agregar cada grupo al checklistbox
            {
                this.clbGrupos.Items.Add(oGrupo);
            }
            if (Modo == "Modificacion")
            {
                this.tbUsuario.Text = oUsuario.USU_CODIGO;
                this.tbUsuario.Enabled = false;
                this.tbEMail.Text = oUsuario.USU_EMAIL;
                this.tbApellido.Text = oUsuario.USU_APELLIDO;
                this.tbNombre.Text = oUsuario.USU_NOMBRE;
                if (oUsuario.USU_ESTADO == true)
                {
                    this.cbEstado.Checked = true;
                }
                else
                {
                    this.cbEstado.Checked = false;
                }
                for (int i = 0; i < clbGrupos.Items.Count; i++) //para i desde 0 hasta la cantidad de items en clbgrupo(todos)
                {
                    oGrupo = (Modelo_Entidades.GRUPO)clbGrupos.Items[i];//mover el grupo con el índice 1 a oGrupo
                    foreach (Modelo_Entidades.GRUPO miGrupo in oUsuario.GRUPOS)//por cada uno de mis grupos en la colección Grupos de oUsuario
                    {
                        if (miGrupo.GRU_CODIGO == oGrupo.GRU_CODIGO)// si el código de oGrupo es igual a miGrupo
                        {
                            clbGrupos.SetItemChecked(i, true);//entonces establezco como checkeado el grupo de índice i
                        }
                    }
                }

                /*
                foreach (Modelo_Entidades.GRUPO oGrupo in oUsuario.GRUPOS)
                {
                    clbGrupos.CheckedItems;
                }
                oUsuario.GRUPOS = (Modelo_Entidades.GRUPO) clbGrupos.SelectedItems;
                //tickear los grupos elegidos
                 * */
            }
            else
            {
                cbEstado.Enabled = false;
                cbEstado.Checked = true;
            }
            
        }

    }
}

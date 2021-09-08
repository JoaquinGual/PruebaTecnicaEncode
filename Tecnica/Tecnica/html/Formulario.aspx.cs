using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Entities;


namespace Tecnica
{
    public partial class Formilario : System.Web.UI.Page
    {

        int id;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Habilitar(true);
                btnModificar.Enabled = false;
                HabilitarInputs(true);
            }
            cmbEstado.Enabled = false;
        }

        //Busca suscriptores en lista y los muestra cargados
        protected void btnBuscar_Click(object sender, EventArgs e) 
        {
            
            cargarCampos();
            
            
        }
        //Permite que cuando se guarde un suscriptor ingrese por la rama de NUEVO
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            BLLSuscriptor.CargarLista("suscriptor");
            Habilitar(false);
            ViewState["nuevo"] = true;
            Limpiar();
            btnBuscar.Enabled = false;
            HabilitarInputs(false);
            txtNumeroDoc.Enabled = true;
        }

        //Cancela la ejecucion limpiando y habilitando campos
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            txtNumeroDoc.Enabled = true;
            Limpiar();
            btnBuscar.Enabled = true;
            btnModificar.Enabled = false;
            HabilitarInputs(true);
            cmbTipo.Enabled = true;
            txtNumeroDoc.Text = "";
            cmbEstado.SelectedIndex = 0;
        }

        //Inserta o Modifica un suscriptor
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool sameDoc = false;
            bool existe = false;
            List<Suscriptor> LS = BLLSuscriptor.CargarLista("Suscriptor");
            if (ValidarDatos())
            {
                
                Entities.Suscriptor s = new Entities.Suscriptor();
                s.pTipoDocumento =  cmbTipo.SelectedValue;
                s.pNumeroDocumento = Convert.ToInt32(txtNumeroDoc.Text);
                s.pNombre = txtNombre.Text;
                s.pApellido = txtApellido.Text;
                s.pDireccion = txtDireccion.Text;
                s.pEmail = txtEmail.Text;
                s.pTelefono = txtTelefono.Text;
                s.pNombreUsuario = txtUser.Text;
                s.pPassword =EncryptKeys.EncriptarPassword(txtContraseña.Text,"Pass");

                if (bool.Parse(ViewState["nuevo"].ToString()) == true)
                {
                    for (int i = 0; i < LS.Count; i++)
                    {
                        if (s.pNumeroDocumento == LS[i].pNumeroDocumento)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "SameDoc();", true);
                            existe = true;
                            break;
                        }
                        if (s.pNombreUsuario == LS[i].pNombreUsuario)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "SameUser();", true);
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false)
                    {
                        if (BLLSuscriptor.InsertarSuscriptor(s) == true)
                        {
                            
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "InsertOk();", true);
                            ViewState["nuevo"] = false;
                            Habilitar(true);
                            btnBuscar.Enabled = true;
                            HabilitarInputs(true);
                            cargarCampos();
                        }
                        else
                        {

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Error();", true);
                        }
                        
                       

                    }
                }
                else
                {
                    for (int i = 0; i < LS.Count; i++)
                    {
                        if (s.pNumeroDocumento == LS[i].pNumeroDocumento)
                        {
                            sameDoc = true;
                            break;
                        }
                        if (s.pNombreUsuario == LS[i].pNombreUsuario && sameDoc == false)
                        {

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "SameUser();", true);
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false && sameDoc == true)
                    {
                        if (BLLSuscriptor.Modificar(s) == true)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "ModifyOk();", true);
                            ViewState["nuevo"] = false;
                            Habilitar(true);
                            btnBuscar.Enabled = true;
                            HabilitarInputs(true);
                            txtNumeroDoc.Enabled = true;
                            btnModificar.Enabled = false;
                            cmbTipo.Enabled = true;
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Error();", true);
                        }
                        
                    }
                   
                }
              


            }

        }

        //Permite modificar un suscriptor
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ViewState["nuevo"] = false;
            Habilitar(false);
            txtNumeroDoc.Enabled = false;
            btnBuscar.Enabled = false;
            btnModificar.Enabled = false;
            cmbTipo.Enabled = false;
            HabilitarInputs(false);
        }

        //Registra nueva suscripcion

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            Entities.Suscripcion s = new Entities.Suscripcion();

            if (ViewState["numerosub"] != null)
            {
                s.pidSuscriptor = (int)ViewState["numerosub"];
            }
            


            if (ValidarDatos())
            {
                if (cmbEstado.SelectedIndex == 2)
                {
                    if (BLLSuscripcion.registrarSuscripcion(s) == true)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "SusOk();", true);
                        cargarCampos();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Error();", true);
                    }
                    
                }
                else

                {
                    if (cmbEstado.SelectedIndex == 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Vigente();", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Unregistered();", true);
                    }
                }
                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "SearchFirst();", true);
            }
        }

        //Valida que todos los datos esten ingresados
        public bool ValidarDatos()
        {
            if (cmbTipo.SelectedIndex == -1)
            {
                

                return false;
            }
            if (txtNumeroDoc.Text == "")
            {
               
                return false;
            }
            if (txtNombre.Text == "")
            {
                
                return false;
            }
            if (txtApellido.Text == "")
            {
                
                return false;
            }
            if (txtDireccion.Text == "")
            {
               
                return false;
            }
            if (txtEmail.Text == "")
            {
                
                return false;
            }
            if (txtTelefono.Text == "")
            {
                
                return false;
            }
            if (txtUser.Text == "")
            {
                
                return false;
            }
            if (txtContraseña.Text == "")
            {
                
                return false;
            }
            return true;
        }

        //Carga los campos con los datos correspondientes
        public void cargarCampos()
        {
            bool flag = false;


            List<Suscriptor> LS = BLLSuscriptor.CargarLista("Suscriptor");
            List<Suscripcion> LIS = BLLSuscripcion.CargarSuscripciones("Suscripcion");

            if (txtNumeroDoc.Text != "" && cmbTipo.SelectedValue != "")
            {
                var suscriptor = LS.FirstOrDefault(a => a.pTipoDocumento == cmbTipo.SelectedValue && a.pNumeroDocumento == int.Parse(txtNumeroDoc.Text));
                if (suscriptor != null)
                {
                    flag = true;
                    id = suscriptor.pId;
                    ViewState["numerosub"] = id;
                    txtNombre.Text = suscriptor.pNombre;
                    txtApellido.Text = suscriptor.pApellido;
                    txtDireccion.Text = suscriptor.pDireccion;
                    txtEmail.Text = Convert.ToString(suscriptor.pEmail);
                    txtTelefono.Text = Convert.ToString(suscriptor.pTelefono);
                    txtUser.Text = suscriptor.pNombreUsuario;
                    txtContraseña.Text = EncryptKeys.DesencriptarPassword(suscriptor.pPassword, "Pass");
                }
                
            }



            //for (int i = 0; i < LS.Count; i++)
            //{
            //    if (txtNumeroDoc.Text != "" && cmbTipo.SelectedValue != "")
            //    {
            //        if (cmbTipo.SelectedValue == LS[i].pTipoDocumento && Convert.ToInt32(txtNumeroDoc.Text) == LS[i].pNumeroDocumento)
            //        {
            //            flag = true;
            //            id = LS[i].pId;
            //            ViewState["numerosub"] = id;
            //            txtNombre.Text = LS[i].pNombre;
            //            txtApellido.Text = LS[i].pApellido;
            //            txtDireccion.Text = LS[i].pDireccion;
            //            txtEmail.Text = Convert.ToString(LS[i].pEmail);
            //            txtTelefono.Text = Convert.ToString(LS[i].pTelefono);
            //            txtUser.Text = LS[i].pNombreUsuario;
            //            txtContraseña.Text = EncryptKeys.DesencriptarPassword(LS[i].pPassword, "Pass");

            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            if (LIS.Count == 0)
            {
                cmbEstado.SelectedIndex = 2;
            }
            var suscripcion = LIS.FirstOrDefault(a => a.pidSuscriptor == id);
            if (suscripcion != null)
            {
                cmbEstado.SelectedIndex = 1;
            }
            else
            {
                cmbEstado.SelectedIndex = 2;
            }
            //for (int i = 0; i < LIS.Count; i++)
            //{

            //    if (LIS[i].pidSuscriptor == id)
            //    {
            //        cmbEstado.SelectedIndex = 1;
            //        break;
            //    }
            //    else
            //    {
            //        cmbEstado.SelectedIndex = 2;

            //    }
            //}
            if (txtNumeroDoc.Text != "" && cmbTipo.SelectedValue != "")
            {
                if (flag == false)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "NotFound();", true);
                    Limpiar();
                    Habilitar(true);
                    btnModificar.Enabled = false;
                    cmbEstado.SelectedIndex = 0;

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Founded();", true);
                    btnModificar.Enabled = true;
                    btnNuevo.Enabled = false;

                }
            }


        }
        //Habilita controles 
        public void Habilitar(bool x)
        {
            btnNuevo.Enabled = x;
            btnGuardar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }
        //Habilita Inputs
        public void HabilitarInputs(bool x)
        {
            txtNombre.Enabled = !x;
            txtApellido.Enabled = !x;
            txtDireccion.Enabled = !x;
            txtEmail.Enabled = !x;
            txtTelefono.Enabled = !x;
            txtUser.Enabled = !x;
            txtContraseña.Enabled = !x;
        }

        //Limpia campos
        private void Limpiar()
        {

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtUser.Text = "";
            txtContraseña.Text = "";
        }

    }
}
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

        protected void btnBuscar_Click(object sender, EventArgs e) 
        {
            
            cargarCampos();
            
            
        }
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
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Limpiar();", true);
        public bool ValidarDatos()
        {
            if (cmbTipo.SelectedIndex == -1)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Tipo();", true);

                return false;
            }
            if (txtNumeroDoc.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Doc();", true);
                return false;
            }
            if (txtNombre.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Nombre();", true);
                return false;
            }
            if (txtApellido.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Apellido();", true);
                return false;
            }
            if (txtDireccion.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Direccion();", true);
                return false;
            }
            if (txtEmail.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Mail();", true);
                return false;
            }
            if (txtTelefono.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Telefono();", true);
                return false;
            }
            if (txtUser.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "User();", true);
                return false;
            }
            if (txtContraseña.Text == "")
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "Pass();", true);
                return false;
            }
            return true;
        }

        public void cargarCampos()
        {
            bool flag = false;


            List<Suscriptor> LS = BLLSuscriptor.CargarLista("Suscriptor");
            List<Suscripcion> LIS = BLLSuscripcion.CargarSuscripciones("Suscripcion");



            for (int i = 0; i < LS.Count; i++)
            {
                if (txtNumeroDoc.Text != "" && cmbTipo.SelectedValue != "")
                {
                    if (cmbTipo.SelectedValue == LS[i].pTipoDocumento && Convert.ToInt32(txtNumeroDoc.Text) == LS[i].pNumeroDocumento)
                    {
                        flag = true;
                        id = LS[i].pId;
                        ViewState["numerosub"] = id;
                        txtNombre.Text = LS[i].pNombre;
                        txtApellido.Text = LS[i].pApellido;
                        txtDireccion.Text = LS[i].pDireccion;
                        txtEmail.Text = Convert.ToString(LS[i].pEmail);
                        txtTelefono.Text = Convert.ToString(LS[i].pTelefono);
                        txtUser.Text = LS[i].pNombreUsuario;
                        txtContraseña.Text = LS[i].pPassword;

                    }                
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < LIS.Count; i++)
            {

                if (LIS[i].pidSuscriptor == id)
                {
                    cmbEstado.SelectedIndex = 1;
                    break;
                }
                else
                {
                    cmbEstado.SelectedIndex = 2;
                    
                }
            }
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

        

        public void Habilitar(bool x)
        {
            btnNuevo.Enabled = x;
            btnGuardar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }

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
                s.pPassword = txtContraseña.Text;

                if (bool.Parse(ViewState["nuevo"].ToString()) == true)
                {
                    for (int i = 0; i < LS.Count; i++)
                    {
                        if (s.pNumeroDocumento == LS[i].pNumeroDocumento)
                        {
                            Response.Write("<script>alert('Ya existe un Usuario con ese DNI!');</script>");
                            existe = true;
                            break;
                        }
                        if (s.pNombreUsuario == LS[i].pNombreUsuario)
                        {
                            Response.Write("<script>alert('Ya existe un Usuario con ese Nombre de Usuario!');</script>");
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false)
                    {
                        BLLSuscriptor.InsertarSuscriptor(s);
                        Response.Write("<script>alert('Usuario Registrado Exitosamente!');</script>");
                        ViewState["nuevo"] = false;
                        Habilitar(true);
                        btnBuscar.Enabled = true;
                        HabilitarInputs(true);

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
                            Response.Write("<script>alert('Ya existe un Usuario con ese Nombre de Usuario!');</script>");
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false && sameDoc == true)
                    {
                        BLLSuscriptor.Modificar(s);
                        Response.Write("<script>alert('Usuario Modificado Exitosamente!');</script>");
                        ViewState["nuevo"] = false;
                        Habilitar(true);
                        btnBuscar.Enabled = true;
                        HabilitarInputs(true);
                        txtNumeroDoc.Enabled = true;
                        btnModificar.Enabled = false;
                        cmbTipo.Enabled = true;
                    }
                   
                }
              


            }

        }

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

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            Entities.Suscripcion s = new Entities.Suscripcion();

            s.pidSuscriptor = (int)ViewState["numerosub"];
            
            
            if (ValidarDatos())
            {
                if (cmbEstado.SelectedIndex == 2)
                {
                    BLLSuscripcion.registrarSuscripcion(s);
                    Response.Write("<script>alert('Usuario Suscrito Correctamente!');</script>");
                    cargarCampos();
                }
                else
                {
                    Response.Write("<script>alert('Este Usuario ya tiene una Suscripcion Vigente!');</script>");
                }
                
            }
        }
    }
}
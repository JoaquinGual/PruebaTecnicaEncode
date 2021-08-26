using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tecnica.clases;

namespace Tecnica
{
    public partial class Formilario : System.Web.UI.Page
    {
        Datos oDatos = new Datos();
        List<Suscriptor> LS = new List<Suscriptor>();
        bool nuevo = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Habilitar(true);
            btnModificar.Enabled = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            cargarCampos();
            
            
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            cargarLista("suscriptor");
            Habilitar(false);
            nuevo = true;
            Limpiar();
            btnBuscar.Enabled = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            txtNumeroDoc.Enabled = true;
            Limpiar();
            btnBuscar.Enabled = true;
        }

        private void Limpiar()
        {
            cmbTipo.SelectedIndex = 0;
            txtNumeroDoc.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtUser.Text = "";
            txtContraseña.Text = "";
        }

        public bool ValidarDatos()
        {
            if (txtNombre.Text == "")
            {
                Response.Write("<script>alert('Ingrese Nombre!');</script>");
                return false;
            }
            if (txtApellido.Text == "")
            {
                Response.Write("<script>alert('Ingrese Apellido!');</script>");
                return false;
            }
            if (txtDireccion.Text == "")
            {
                Response.Write("<script>alert('Ingrese Direccion!');</script>");
                return false;
            }
            if (txtEmail.Text == "")
            {
                Response.Write("<script>alert('Ingrese Email!');</script>");
                return false;
            }
            if (txtTelefono.Text == "")
            {
                Response.Write("<script>alert('Ingrese Telefono!');</script>");
                return false;
            }
            return true;
        }

        public void cargarCampos()
        {
            bool flag = false;
            cargarLista("Suscriptor");
            for (int i = 0; i < LS.Count; i++)
            {
                if (txtNumeroDoc.Text != "" && cmbTipo.SelectedValue != "")
                {
                    if (cmbTipo.SelectedValue == LS[i].pTipoDocumento && Convert.ToInt32(txtNumeroDoc.Text) == LS[i].pNumeroDocumento)
                    {
                        flag = true;
                        txtNombre.Text = LS[i].pNombre;
                        txtApellido.Text = LS[i].pApellido;
                        txtDireccion.Text = LS[i].pDireccion;
                        txtEmail.Text = Convert.ToString(LS[i].pTelefono);
                        txtTelefono.Text = Convert.ToString(LS[i].pTelefono);
                        txtUser.Text = LS[i].pNombreUsuario;
                        txtContraseña.Text = LS[i].pPassword;

                    }
                    
                }
                else
                {
                    Response.Write("<script>alert('Ingrese Tipo y Numero de documento!')</script>");
                    break;
                }



            }
            if (txtNumeroDoc.Text != "" && cmbTipo.SelectedValue != "")
            {
                if (flag == false)
                {
                    Response.Write("<script>alert('No se ha encontrado ningun usuario con esos datos!')</script>");
                    Limpiar();
                }
                else
                {
                    Response.Write("<script>alert('Datos cargados correctamente')</script>");
                    btnModificar.Enabled = true;
                }
            }
                

        }

        public void cargarLista(string Tabla)
        {
            oDatos.LeerTabla(Tabla);
            LS.Clear();
            while (oDatos.Lector.Read())
            {
                Suscriptor s = new Suscriptor();

                
                if (!oDatos.Lector.IsDBNull(1))
                {
                    s.pNombre = oDatos.Lector.GetString(1);
                }
                if (!oDatos.Lector.IsDBNull(2))
                {
                    s.pApellido = oDatos.Lector.GetString(2);
                }
                if (!oDatos.Lector.IsDBNull(3))
                {
                    s.pNumeroDocumento = oDatos.Lector.GetInt32(3);
                }
                if (!oDatos.Lector.IsDBNull(4))
                {
                    s.pTipoDocumento = oDatos.Lector.GetString(4);
                }
                if (!oDatos.Lector.IsDBNull(5))
                {
                    s.pDireccion = oDatos.Lector.GetString(5);
                }
                if (!oDatos.Lector.IsDBNull(6))
                {
                    s.pTelefono = oDatos.Lector.GetString(6);
                }
                if (!oDatos.Lector.IsDBNull(7))
                {
                    s.pEmail = oDatos.Lector.GetString(7);
                }
                if (!oDatos.Lector.IsDBNull(8))
                {
                    s.pNombreUsuario = oDatos.Lector.GetString(8);
                }
                if (!oDatos.Lector.IsDBNull(9))
                {
                    s.pPassword = oDatos.Lector.GetString(9);
                }
                LS.Add(s);
            }
            oDatos.Desconectar();
        }

        public void Habilitar(bool x)
        {
            btnNuevo.Enabled = x;
            btnGuardar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string consultaSQL = "";
            bool existe = false;
            cargarLista("suscriptor");
            if (ValidarDatos())
            {
                Suscriptor s = new Suscriptor();
                s.pTipoDocumento = cmbTipo.SelectedValue;
                s.pNumeroDocumento = Convert.ToInt32(txtNumeroDoc.Text);
                s.pNombre = txtNombre.Text;
                s.pApellido = txtApellido.Text;
                s.pDireccion = txtDireccion.Text;
                s.pEmail = txtEmail.Text;
                s.pTelefono = txtTelefono.Text;
                s.pNombreUsuario = txtUser.Text;
                s.pPassword = txtContraseña.Text;

                if (nuevo == true)
                {
                    for (int i = 0; i < LS.Count; i++)
                    {
                        if (s.pNumeroDocumento == LS[i].pNumeroDocumento)
                        {
                            Response.Write("<script>alert('Ya existe un Usuario con ese DNI!');</script>");
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false)
                    {
                        consultaSQL = $"insert into Suscriptor (Nombre,Apellido,NumeroDocumento,TipoDocumento,Direccion,Telefono,Email,NombreUsuario,Password) " +
                                      $"values ('{s.pNombre}','{s.pApellido}','{s.pNumeroDocumento}','{s.pTipoDocumento}','{s.pDireccion}','{s.pTelefono}','{s.pEmail}','{s.pNombreUsuario}','{s.pPassword}')";
                        oDatos.Actualizar(consultaSQL);
                        Response.Write("<script>alert('Usuario Registrado Exitosamente!');</script>");

                    }
                }
                else
                {
                    
                    consultaSQL = $"update Suscriptor set  Nombre= '{s.pNombre}',Apellido= '{s.pApellido}',Direccion='{s.pDireccion}',Telefono='{s.pTelefono}',Email='{s.pEmail}',NombreUsuario='{s.pNombreUsuario}',Password='{s.pPassword}' where NumeroDocumento ='{txtNumeroDoc.Text}'";
                    oDatos.Actualizar(consultaSQL);
                    cargarLista("Suscriptor");
                    Response.Write("<script>alert('Usuario Actualizado Correctamente');</script>");
                    txtNumeroDoc.Enabled = true;
                }
                nuevo = false;
                Habilitar(true);
                btnBuscar.Enabled = true;

            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            Habilitar(false);
            txtNumeroDoc.Enabled = false;
            btnBuscar.Enabled = false;

        }
    }
}
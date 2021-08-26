<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Tecnica.Formilario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <title>Suscripciones</title>
</head>
<body>
          <form id="form1" runat="server">
          <!-- Formulario -->
    <div class="container">
      <h2>Sucripcion</h2>
      <h5>Para realizar la suscripcion complete los siguientes datos:</h5>
    </div>
    <div class="container">
      <hr>
      <h3>Buscar suscriptor</h3>
      <div class="form-row">
        <div class="form-group col-md-5">
                      <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo Documento"></asp:Label>              
          <asp:DropDownList ID="cmbTipo" runat="server" CssClass="form-control">
              <asp:ListItem>DNI</asp:ListItem>
              <asp:ListItem>L.E</asp:ListItem>
              <asp:ListItem>C.I</asp:ListItem>
              <asp:ListItem>Pasaporte</asp:ListItem>
                      </asp:DropDownList>
        </div>
        <div class="form-group col-md-5">
            <asp:Label ID="lblNumeroDoc" runat="server" Text="Numero de Documento"></asp:Label>
          <asp:TextBox ID="txtNumeroDoc" runat="server" placeholder="Numero de Documento" CssClass="form-control"></asp:TextBox>
        </div>
          <div  class="form-group col-md-2">
              <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
          </div>
      </div>

      <hr>
      <h3>Datos del Suscriptor
        </h3>
      <div class="form-row">
        <div class="form-group col-md-5"
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="form-group col-md-5">   
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido" CssClass="form-control"></asp:TextBox>
          </div>

        </div>
        <div class="form-row">
          <div class="form-group col-md-5">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion" CssClass="form-control"></asp:TextBox>
          </div>
          <div class="form-group col-md-5">
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
          </div>

        </div>
        <div class="form-row">
        <div class="form-group col-md-5">
              <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" placeholder="Telefono" CssClass="form-control"></asp:TextBox>
        </div>
            </div>
         <div class="form-row">
                <div class="form-group col-md-2">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-info" OnClick="btnNuevo_Click" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-warning" OnClick="btnGuardar_Click" />
                </div>
             <div class="form-group col-md-2">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                </div>
            </div>
      <hr>
      <div class="form-row">
        <div class="form-group col-md-6">
              <asp:Label ID="lblNombreUser" runat="server" Text="Nombre de Usuario"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server" placeholder="Nombre de Usuario" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
              <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtContraseña" runat="server" placeholder="Contraseña" CssClass="form-control" type="password"></asp:TextBox>
        </div>
      </div>

        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Suscripcion" CssClass="btn btn-dark" />
    </div>
    <!-- Fin ormulario -->
    

    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.3/dist/jquery.validate.min.js"></script>
    <!-- <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script> -->
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
              <p>
                  &nbsp;</p>
          </form>
</body>
</html>

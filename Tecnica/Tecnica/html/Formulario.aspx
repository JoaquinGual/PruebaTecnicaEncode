<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Tecnica.Formilario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <title>Suscripciones</title>
</head>
<body>
    <!-- Formulario -->
    <form id="formulario" runat="server" name="formulario">

        <div class="container">
            <h2>Sucripcion</h2>
            <h5>Para realizar la suscripcion complete los siguientes datos:</h5>
        </div>
        <div class="container">
            <hr />
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
                    <asp:TextBox ID="txtNumeroDoc" runat="server" name="doc" placeholder="Numero de Documento" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
                </div>
            </div>

            <hr />
            <h3>Datos del Suscriptor
            </h3>
            <div class="form-row">
                <div class="form-group col-md-5">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" CssClass="form-control" name="nombre"></asp:TextBox>
                </div>
                <div class="form-group col-md-5">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido" CssClass="form-control" name="apellido"></asp:TextBox>
                </div>

            </div>
            <div class="form-row">
                <div class="form-group col-md-5">
                    <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
                    <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion" CssClass="form-control" name="direccion"></asp:TextBox>
                </div>
                <div class="form-group col-md-5">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control" name="email"></asp:TextBox>
                </div>

            </div>
            <div class="form-row">
                <div class="form-group col-md-5">
                    <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" placeholder="Telefono" CssClass="form-control" name="telefono"></asp:TextBox>

                </div>
                <div class="form-group col-md-5">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                    <asp:DropDownList ID="cmbEstado" runat="server" CssClass="form-control">
                        <asp:ListItem>-</asp:ListItem>
                        <asp:ListItem>Suscrito</asp:ListItem>
                        <asp:ListItem>No Suscrito</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-2">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-info" OnClick="btnNuevo_Click" UseSubmitBehavior="False" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" UseSubmitBehavior="False" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnGuardar" type="sumbit" runat="server" Text="Guardar" CssClass="btn btn-warning" OnClick="btnGuardar_Click" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" UseSubmitBehavior="False" />
                </div>
            </div>
            <hr>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="lblNombreUser" runat="server" Text="Nombre de Usuario"></asp:Label>
                    <asp:TextBox ID="txtUser" runat="server" placeholder="Nombre de Usuario" CssClass="form-control" name="user"></asp:TextBox>
                </div>
                <div class="form-group col-md-6">
                    <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtContraseña" runat="server" placeholder="Contraseña" CssClass="form-control" type="password" name="pass"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Suscripcion" CssClass="btn btn-dark" OnClick="btnRegistrar_Click" />
        </div>

        <!-- Fin ormulario -->

        <%-- Metodos para ejecutar Sweet Alert --%>
        <script>
            function Vigente() {
                swal("Este Usuario ya tiene una Suscripcion vigente!");
            }
            function NotFound() {
                swal("No se ha encontrado ningun usuario con esos datos!");
            }
            function Founded() {
                swal("Datos Cargados!");
            }
            function SusOk() {
                swal("Usuario Suscrito correctamente!");
            }
            function ModifyOk() {
                swal("Usuario Modificado con Exito!");
            }
            function SameUser() {
                swal("Ya existe un registro con el mismo Nombre de Usuario");
            }
            function InsertOk() {
                swal("Usuario Registrado Correctamente!");
            }
            function SameDoc() {
                swal("Ya existe un Usuario con ese numero de Documento");
            }
            function SearchFirst() {
                swal("Busque un suscriptor registrado antes de registrar la suscripcion!");
            }
            function Error() {
                swal("Hubo un error inesperado, intentelo de nuevo mas tarde!");
            }
            function Unregistered() {
                swal("Se debe registrar el usuario antes de obtener una suscripcion!!");
            }
        </script>

        <!-- jQuery first, then Popper.js, then Bootstrap JS -->

        <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.3/dist/jquery.validate.min.js"></script>
        <script type='text/javascript' src='/NuevoOva/Validacion/jquery-validation-1.8.1/additional-methods.js'></script>


        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
        <script src="../js/main.js"></script>
        <%-- Valida que todos los datos esten correctamente ingresados con jquery validate --%>
        <script>
            $(function () {
                jQuery.validator.addMethod("lettersonly", function (value, element) {
                    return this.optional(element) || /^[a-z]+$/i.test(value);
                }, "Solo letras");
                $("form[id='formulario']").validate({
                    rules: {
                        txtNumeroDoc: {
                            required: true,
                            digits: true
                        },
                        txtNombre: {
                            required: true,
                            lettersonly: true
                        },
                        txtApellido: {
                            required: true,
                            lettersonly: true
                        },
                        txtDireccion: "required",
                        txtEmail: {
                            required: true,
                            minlength: 5,
                            email: true
                        },
                        txtTelefono: {
                            required: true,
                            digits: true,

                        },
                        txtUser: {
                            
                            required: true
                        },
                        txtContraseña: {
                            required: true,
                            minlength: 5,

                        },



                    },
                    messages: {
                        txtNumeroDoc: "Ingrese Documento",
                        txtNombre: "Ingrese un nombre",
                        txtApellido: "Ingrese un apellido",
                        txtDireccion: "Ingrese una direccion",
                        txtEmail: "Ingrese un mail valido",
                        txtTelefono: "Ingrese un telefono valido",
                        txtUser: "Ingrese un Nombre de Usuario",
                        txtContraseña: "Ingrese una contraseña valida",

                    },


                    submitHandler: function (form) {
                        form.submit();
                    }

                });
            });
        </script>
    </form>

</body>
</html>

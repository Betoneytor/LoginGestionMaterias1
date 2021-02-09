<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="FrontEndV2.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
     <link rel="stylesheet" href="/Bootstrap/CSS/bootstrap.min.css">
    
    <link rel="stylesheet" type="text/css" href="./CSS/DataTable/jquery.dataTables.min.css">

    <script type="text/javascript" charset="utf8" src="./JS/DataTable/jquery-3.5.1.js"></script>
    <script type="text/javascript" charset="utf8" src="./JS/DataTable/jquery.dataTables.min.js"></script>
    

     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/bootstrap.min.js"></script>
     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/jquery-3.3.3.slim.min.js"></script>
     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/popper.min.js"></script>
</head>
<body>
   <form id="form1" runat="server" novalidate>

        <!-------------------INICIO MODAL---------------------->
    <div class="modal" id="mdlAvisoRedireccionPorRegistro" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 style="color:#030746;" class="modal-title" >Registro Exitoso</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p style="color:#030746;" >Usuario registrado exitosamente, se procede a mostrar menu de usuario</p>
      </div>
      <div class="modal-footer">
        
        <asp:Button ID="btnRedireccion" CssClass="btn btn-success"  OnClick="btnRedireccion_Click" runat="server" Text="Ok" />
      </div>
    </div>
  </div>
</div>
    <!--FIN MODAL -->

     <div id="login">
        <h3 class="text-center text-white pt-5">Login form</h3>
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">

                            <h3 class="text-center text-info">Login</h3>
                            <div class="form-group">
                                <label for="txtEmail">Email</label>
                                <asp:TextBox ID="txtEmail" TextMode="Email" autocomplete="off" class="form-control"  runat="server" required></asp:TextBox>
                                  <div class="invalid-feedback">
                                    El correo electrónico es obligatorio y debe tener un formato válido
                                  </div>
                            </div>
                            <div class="form-group">
                                <label for="txtContrasena">Contraseña</label>
                                    <asp:TextBox ID="txtContrasena" TextMode="Password" class="form-control"   autocomplete="off" runat="server" required MaxLength="20"></asp:TextBox>
                                  <div class="invalid-feedback">
                                    La Contraseña es obligatoria y debe tener un formato válido
                                  </div>
                            </div>
                            <div class=" form-group">
                                <asp:Button ID="btnIniciarSesion" class="btn btn-success float-left" runat="server" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" margin-left="50px"/>
                                
                                 <asp:Button ID="btnRegistrar" class="btn btn-info float-right" runat="server" Text="Registrar" OnClick="btnRegistrar_Click"  />
                            </div>
                            <div id="divlblError" class="text-center">
                                <br />
                                <asp:Label ID="lblInfoError" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                               
                                <asp:Label ID="lblInfoPositiva" runat="server" Font-Bold="True" ForeColor="#008f39"></asp:Label>
                                <br />
                            </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
       </form>
    
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuForm.aspx.cs" Inherits="FrontEndV2.MenuForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu</title>
       <link rel="stylesheet" href="/Bootstrap/CSS/bootstrap.min.css">
</head>
<body>
     <form id="form1" runat="server" novalidate>
     <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">

                       

                            <h1 class="text-center text-info">Menú</h1>
                           
                         <div class="form-group">
                              <asp:Label ID="lblUsr" runat="server" Font-Bold="True" ForeColor="#030746" Font-Size="Larger"></asp:Label>
                         </div>
                            
                            <div class="form-group">
                                <asp:Button ID="btnGestionarMaterias" class="btn btn-info float-left" runat="server" Font-Bold="True" Text="Gestionar Mis Materias" OnClick="btnGestionarMaterias_Click" />
                                <br>
                                <br>
                               <asp:Button ID="btnCerrarSesion" class="btn btn-warning  float-left" Font-Bold="True"  runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                            </div>
                        
                           
                       
                           
                       
                       
                    </div>
                </div>
            </div>
        </div>
         </form>
</body>
</html>

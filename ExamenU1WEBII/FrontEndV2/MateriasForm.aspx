<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MateriasForm.aspx.cs" Inherits="FrontEndV2.MateriasForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestion De Materias</title>

    <link rel="stylesheet" href="/Bootstrap/CSS/bootstrap.min.css">
    
    <link rel="stylesheet" type="text/css" href="./CSS/DataTable/jquery.dataTables.min.css">
    
    
    <script type="text/javascript" charset="utf8" src="./JS/DataTable/jquery-3.5.1.js"></script>
    <script type="text/javascript" charset="utf8" src="./JS/DataTable/jquery.dataTables.min.js"></script>
    <script type="text/javascript" charset="utf8" src="./JS/MateriasForm.js"></script>

     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/bootstrap.min.js"></script>
     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/jquery-3.3.3.slim.min.js"></script>
     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/popper.min.js"></script>
    

</head>
<body>
  <form id="form1" runat="server" novalidate>
      <div class="form-group">
          
          <asp:Label ID="lblUsr" runat="server" Font-Bold="True" ForeColor="#030746" Font-Size="Larger"></asp:Label>
          <asp:Button ID="btnCerrarSesion" class="btn btn-warning  float-right" Font-Bold="True"  runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
          <h3>Tus Materias</h3>

      </div>
    

       <!-------------------INICIO MODAL---------------------->
    <div class="modal" id="mdlConfirmarEliminar" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Confirmar Eliminar</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p>Estás seguro que deseas eliminar?</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
        <asp:Button ID="btnConfirmarEliminar" CssClass="btn btn-danger"  OnClick="btnConfirmarEliminar_Click" runat="server" Text="Eliminar" />
      </div>
    </div>
  </div>
</div>
    <!--FIN MODAL -->


        <asp:HiddenField ID="IdMateria" runat="server" />
        
        
      <asp:HiddenField ID="idAgregarMateria" runat="server" Value="0"/>
        <div class="form-row">
            <div class="col-md-6">
                <asp:Label ID="lblAgregarEditarMaterias" for="txtAgregarEditarMaterias" runat="server" Font-Bold="True" ForeColor="#030746" Text="Nombre Materia" ></asp:Label>
                <asp:TextBox ID="txtAgregarEditarMaterias" CssClass="form-control" placeholder="Nombre Materia" runat="server" autocomplete="off"></asp:TextBox>
                <div class="valid-feedback">
                    Formato Correcto!
                </div>
                <div class="invalid-feedback">
                    El nombre de la Materia es obligatorio y tener de 5 hasta 30 caracteres.
                </div>
            </div>
            
        </div>
        <div class="form-group">
            <asp:Label ID="lblInfoError" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label><br />
            <button id="btnValidar" type="button" class="btn btn-info">Validar Nombre</button>
             &nbsp;  &nbsp;  &nbsp;  &nbsp; 
            <asp:Button ID="btnAceptar" CssClass="btn btn-success" runat="server" Text="Agregar Materia" OnClick="btnAceptar_Click"  />
            
            
        </div>
       
        <asp:GridView ID="gvMaterias" CssClass="table table-bordered table-striped" runat="server" 
             DataKeyNames="idMateria" OnRowCommand="gvMaterias_RowCommand">
            <Columns>
                <asp:BoundField DataField="idMateria" HeaderText="Clave" />
                <asp:BoundField DataField="nombre" HeaderText="Materia" />
                <asp:ButtonField CommandName="Eliminar"  ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar"/>
                <asp:ButtonField CommandName="Editar" ButtonType="Button" ControlStyle-CssClass="btn btn-info" Text="Editar"/>
                <asp:ButtonField CommandName="Gestionar" ButtonType="Button" ControlStyle-CssClass="btn btn-success" Text="Gestionar Calificaciones"/>
                
               
            </Columns>
        </asp:GridView>
   
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalificacionesForm.aspx.cs" Inherits="FrontEndV2.CalificacionesForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestion de Calificaciones</title>
 <link rel="stylesheet" href="/Bootstrap/CSS/bootstrap.min.css">
    
    <link rel="stylesheet" type="text/css" href="./CSS/DataTable/jquery.dataTables.min.css">
    
    
    <script type="text/javascript" charset="utf8" src="./JS/DataTable/jquery-3.5.1.js"></script>
    <script type="text/javascript" charset="utf8" src="./JS/DataTable/jquery.dataTables.min.js"></script>
    <script type="text/javascript" charset="utf8" src="./JS/CalificacionesForm.js"></script>

     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/bootstrap.min.js"></script>
     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/jquery-3.3.3.slim.min.js"></script>
     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/popper.min.js"></script></head>
<body>
    <form id="form1" runat="server" novalidate>
     <div class="form-group">
          <asp:Label ID="lblUsr" runat="server" Font-Bold="True" ForeColor="#030746" Font-Size="Larger"></asp:Label>
         <h3>Tus Calificaciones</h3>
         <asp:Button ID="btnCerrarSesion" class="btn btn-warning  float-right" Font-Bold="True"  runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
         <asp:Button ID="btnRegresar" class="btn btn-info  float-right" Font-Bold="True"  runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
       

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


        <asp:HiddenField ID="IdUnidad" runat="server" />
        
        
      <asp:HiddenField ID="idAgregarUnidad" runat="server" Value="0"/>
         <asp:Label ID="lblMatereriaGestionando" runat="server" Font-Bold="True" ForeColor="#030746" Font-Size="Medium"></asp:Label>
        <div class="form-row">
            <div class="col-md-6">
                <asp:Label ID="lblAgregarEditarNUnidad" for="lblAgregarEditarNUnidad" runat="server" Font-Bold="True" ForeColor="#030746" Text=" Numero Unidad" ></asp:Label>
                <asp:TextBox ID="txtAgregarEditarNUnidad" CssClass="form-control" placeholder="Numero Unidad" runat="server" autocomplete="off"></asp:TextBox>
                <div class="valid-feedback">
                    Formato Correcto!
                </div>
                <div class="invalid-feedback">
                    El numero de la unidad es obligatorio y debe tener solo numeros del 1 al 15.
                </div>
               
            </div>
            
        </div>
        <div class="form-row">
            <div class="col-md-6">
                <asp:Label ID="lblAgregarEditarCalificacion" for="txtAgregarEditarCalificacion" runat="server" Font-Bold="True" ForeColor="#030746" Text="Agregar Calificacion" ></asp:Label>
                <asp:TextBox ID="txtAgregarEditarCalificacion" CssClass="form-control" placeholder="Calificacion" runat="server" autocomplete="off"></asp:TextBox>
                <div class="valid-feedback">
                    Formato Correcto!
                </div>
                <div class="invalid-feedback">
                     El numero de la Calificacion es obligatorio y debe tener solo numeros del 1 al 100.
                </div>
            </div>
            
        </div>
        <div class="form-group">
            <asp:Label ID="lblInfoError" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label><br />
            <button id="btnValidar" type="button" class="btn btn-info">Validar</button>
             &nbsp;  &nbsp;  &nbsp;
            <asp:Button ID="btnAceptar" CssClass="btn btn-success" runat="server" Text="Agregar Calificacion" OnClick="btnAceptar_Click"  />
            
            
        </div>
       
        <asp:GridView ID="gvUnidades" CssClass="table table-bordered table-striped" runat="server" 
             DataKeyNames="numeroUnidad" OnRowCommand="gvUnidades_RowCommand">
            <Columns>
                <asp:BoundField DataField="idUnidad" HeaderText="Clave" />
                <asp:BoundField DataField="numeroUnidad" HeaderText="Unidad" />
                <asp:BoundField DataField="calificacionUnidad" HeaderText="Calificacion" />
                <asp:ButtonField CommandName="Eliminar"  ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar"/>
                <asp:ButtonField CommandName="Editar" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Editar"/>
            </Columns>
        </asp:GridView>
   
    </form>
</body>
</html>

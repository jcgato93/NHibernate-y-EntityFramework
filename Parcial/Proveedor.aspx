<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs" Inherits="Parcial.Proveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <h1>Proveedor</h1>

    <div class="row" style="margin-top:3em; margin-bottom:2em">
        <div class="col-lg-5">
            <h3><strong>Nombres</strong></h3>
            <asp:TextBox ID="txtNombres" CssClass="form-control" placeHolder="Nombres" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="nombres" runat="server" ErrorMessage="Faltan los Nombres" ControlToValidate="txtNombres" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>

        </div>
        <div class="col-lg-5">
            <h3><strong>Apellidos</strong></h3>
            <asp:TextBox ID="txtApellidos" CssClass="form-control" placeHolder="Apellidos" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="apellidos" runat="server" ErrorMessage="Faltan los Apellidos" ControlToValidate="txtApellidos" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>

        </div>
           
        <div class="col-lg-5">
            <h3><strong>Direccion</strong></h3>
            <asp:TextBox ID="txtDireccion" CssClass="form-control" placeHolder="Direccion" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="direccion" runat="server" ErrorMessage="Falta Direccion" ControlToValidate="txtDireccion" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        </div>

        <div class="col-lg-5">
            <h3><strong>Telefono</strong></h3>
            <asp:TextBox ID="txtTelefono" CssClass="form-control" placeHolder="Telefono" TextMode="Number" MaxLength="10" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="telefono" runat="server" ErrorMessage="Falta Telefono" ControlToValidate="txtTelefono" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        </div>

        <div class="col-lg-5">
            <h3><strong>Correo</strong></h3>
            <asp:TextBox ID="txtCorreo" CssClass="form-control" placeHolder="Email" TextMode="Email"  runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="corre" runat="server" ErrorMessage="Falta Correo" ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        </div>

         <div class="col-lg-5">
            <h3><strong>Membresia</strong></h3>
            <asp:DropDownList ID="ddlMembresia" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="col-lg-2">
            <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Agregar" OnClick="btnAdd_Click" ValidationGroup="grupo1" />
        </div>
    </div>

    <div class="row">
        <asp:GridView ID="gridProveedor" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="5" CssClass="table table-hover table-responsive" PageSize="5" OnRowCommand="gridCategorias_RowCommand" OnPageIndexChanging="gridCategorias_PageIndexChanging" >
                        <Columns>
                            <asp:ButtonField ButtonType="Image" CommandName="Details" HeaderText="Details" ImageUrl="~/Recursos/Icons/Details_50px.png" />
                        </Columns>
                            <FooterStyle BackColor="#F7F9F9" ForeColor="#F7F9F9"/>
                            <HeaderStyle BackColor="#2874A6" Font-Bold="True" ForeColor="#F7F9F9"/>
                            <PagerStyle CssClass="gridViewPager" BackColor="#2874A6" ForeColor="#F7F9F9" HorizontalAlign="Center" Font-Bold="true"/>
                            <RowStyle ForeColor="#2874A6" BackColor="White"/>
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"/>
                            <SortedAscendingCellStyle BackColor="#F7F9F9" />
                            <SortedAscendingHeaderStyle BackColor="#F7F9F9" />
                            <SortedDescendingCellStyle BackColor="#F7F9F9" />
                            <SortedDescendingHeaderStyle BackColor="#F7F9F9" />
                            </asp:GridView>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <%-- Modal popupExtender --%>
    <asp:Button runat="server" ID="btnShowModalPopup" style="display:none"/>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="btnShowModalPopup"
    PopupControlID="divPopUp"
    BackgroundCssClass="popUpStyle"    
    OkControlID="btnOk"
    DropShadow="true"   
    CancelControlID="btnClose"
    />
    <%-- /Modal popupExtender --%>

    
    <%-- Modal Details--%>
      <div class="panel panel-primary" style="display:none;" id="divPopUp">
          <div class="panel-heading">
            <h3 class="panel-title">Producto</h3>
          </div>
          <div class="panel-body">
            <div class="container" style="height:800px; overflow:scroll;">
                <asp:TextBox ID="txtId" runat="server" Visible="false"></asp:TextBox>
                
              <div class="row" style="margin-top:3em; margin-bottom:2em">
                    <div class="col-lg-5">
                    <h3><strong>Nombres</strong></h3>
                    <asp:TextBox ID="txtNombresEdit" CssClass="form-control" placeHolder="Nombres" runat="server"></asp:TextBox>            
                </div>
                <div class="col-lg-5">
                    <h3><strong>Apellidos</strong></h3>
                    <asp:TextBox ID="txtApellidosEdit" CssClass="form-control" placeHolder="Apellidos" runat="server" ></asp:TextBox>            
                </div>
           
                <div class="col-lg-5">
                    <h3><strong>Direccion</strong></h3>
                    <asp:TextBox ID="txtDireccionEdit" CssClass="form-control" placeHolder="Direccion" runat="server" ></asp:TextBox>            
                </div>

                <div class="col-lg-5">
                    <h3><strong>Telefono</strong></h3>
                    <asp:TextBox ID="txtTelefonoEdit" CssClass="form-control" placeHolder="Telefono" TextMode="Number" MaxLength="10" runat="server" ></asp:TextBox>
            
                </div>

                <div class="col-lg-5">
                    <h3><strong>Correo</strong></h3>
                    <asp:TextBox ID="txtCorreoEdit" CssClass="form-control" placeHolder="Email" TextMode="Email"  runat="server" ></asp:TextBox>            
                </div>

                 <div class="col-lg-5">
                    <h3><strong>Membresia</strong></h3>
                    <asp:DropDownList ID="ddlMembresiaEdit" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                
                <%-- Body --%>
                <asp:Button ID="btnUpdate" runat="server" Text="Actulizar" CssClass="btn btn-primary" Width="100px" OnClick="btnOk_Click"/>
               
                </div>
              <div class="container">
                <div class="row">
                    <asp:Button ID="btnOk" runat="server" Text="" CssClass="btn btn-success" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" Width="100px" ForeColor="White" OnClick="btnEliminar_Click"/>
                    <asp:Button ID="btnClose" runat="server" Text="Cancel" CssClass="btn btn-warning" Width="100px" />
                </div>
            </div>
          </div>
    </div>


    <%-- /Modal --%>


</asp:Content>

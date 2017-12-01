<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Parcial.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1>Producto</h1>

    <div class="row" style="margin-top:3em; margin-bottom:2em">
        <div class="col-lg-5">
            <h3><strong> Descripcion</strong></h3>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" placeHolder="Descripcion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valDescripcion" runat="server" ErrorMessage="Falta Descripcion" ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>

        </div>
        <div class="col-lg-5">
            <h3><strong>Cantidad</strong></h3>
            <asp:TextBox ID="txtCantidad" CssClass="form-control" placeHolder="Cantidad" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valCantidad" runat="server" ErrorMessage="Falta Cantidad" ControlToValidate="txtCantidad" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>

        </div>
           
        <div class="col-lg-5">
            <h3><strong>Valor</strong></h3>
            <asp:TextBox ID="txtValor" CssClass="form-control" placeHolder="Valor" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valValor" runat="server" ErrorMessage="Falta Valor" ControlToValidate="txtValor" ForeColor="Red" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        </div>

        <div class="col-lg-5">
            <h3><strong>Proveedor</strong></h3>
            <asp:DropDownList ID="ddlProveedor" CssClass="form-control" runat="server"></asp:DropDownList>            
        </div>

        <div class="col-lg-5">
            <h3><strong>Categoria</strong></h3>
            <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>            
        </div>

        <div class="col-lg-12">
            <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Agregar" OnClick="btnAdd_Click" ValidationGroup="grupo1" />
        </div>
    </div>

    <%-- filtros de busqueda --%>
    <div class="row" style="margin-top:5em; margin-bottom:3em">
        <div class="col-lg-12" style="margin-bottom:2em"><h3>Buscar</h3></div>

           <div class="col-lg-5">
            <h3><strong>Proveedor</strong></h3>
            <asp:DropDownList ID="ddlProveedorBuscar" CssClass="form-control" runat="server"></asp:DropDownList>            
        </div>

        <div class="col-lg-5">
            <h3><strong>Categoria</strong></h3>
            <asp:DropDownList ID="ddlCategoriaBuscar" CssClass="form-control" runat="server"></asp:DropDownList>            
        </div>

        <div class="col-lg-12">
            <asp:Button ID="btnBuscar" CssClass="btn btn-success" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
        </div>
        
    </div>


    <div class="row">
        <asp:GridView ID="gridProducto" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="5" CssClass="table table-hover table-responsive" PageSize="5" OnRowCommand="gridCategorias_RowCommand" OnPageIndexChanging="gridCategorias_PageIndexChanging" >
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
            <h3><strong> Descripcion</strong></h3>
            <asp:TextBox ID="txtDescripcionEdit" CssClass="form-control" placeHolder="Descripcion" runat="server"></asp:TextBox>
            

        </div>
        <div class="col-lg-5">
            <h3><strong>Cantidad</strong></h3>
            <asp:TextBox ID="txtCantidadEdit" CssClass="form-control" placeHolder="Cantidad" runat="server" TextMode="Number"></asp:TextBox>           
        </div>
           
        <div class="col-lg-5">
            <h3><strong>Valor</strong></h3>
            <asp:TextBox ID="txtValorEdit" CssClass="form-control" placeHolder="Valor" runat="server" TextMode="Number"></asp:TextBox>            
        </div>

        <div class="col-lg-5">
            <h3><strong>Proveedor</strong></h3>
            <asp:DropDownList ID="ddlProveedorEdit" CssClass="form-control" runat="server"></asp:DropDownList>            
        </div>

        <div class="col-lg-5">
            <h3><strong>Categoria</strong></h3>
            <asp:DropDownList ID="ddlCategoriaEdit" CssClass="form-control" runat="server"></asp:DropDownList>            
        </div>

   
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

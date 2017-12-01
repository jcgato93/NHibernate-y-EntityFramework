using Parcial.Logica.ModelNH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillForm();
            }
        }

        //inserta
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ddlCategoria.SelectedValue.Equals("-1") && !ddlProveedor.SelectedValue.Equals("-1"))
            {
                NHProducto producto = new NHProducto();
                producto.Cantidad = int.Parse(txtCantidad.Text);
                producto.Descripcion = txtDescripcion.Text;
                producto.CodigoCat = int.Parse(ddlCategoria.SelectedValue);
                producto.IdentificacionProv = int.Parse(ddlProveedor.SelectedValue);

                string result = Parcial.Logica.ClasesNH.clsNHProducto.InsertProducto(producto);

                Response.Write("<script>alert('" + result + "')</script>");

                txtDescripcion.Text = string.Empty;
                txtCantidad.Text = string.Empty;
               

                BindGrid();
            }
            else
            {
                Response.Write("<script>alert('Seleccione un Proveedor y una Categoria')</script>");
            }
        }


        //Row Command
        protected void gridCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "Details":

                    txtId.Text = gridProducto.Rows[index].Cells[1].Text;
                    Logica.ClasesNH.clsNHCategoria.fillDropDownConCategorias(ref ddlCategoriaEdit);
                    Logica.ClasesNH.clsNHProveedor.fillDropDownConProveedores(ref ddlProveedorEdit);

                    NHProducto producto = Parcial.Logica.ClasesNH.clsNHProducto.ConsultarProductosPorCodigo(int.Parse(txtId.Text));

                    //Re-set controlls
                    txtDescripcionEdit.Text = producto.Descripcion;
                    txtCantidadEdit.Text = producto.Cantidad.ToString();
                    txtValorEdit.Text = producto.Valor.ToString();
                    ddlCategoriaEdit.SelectedValue = producto.CodigoCat.ToString();
                    ddlProveedorEdit.SelectedValue = producto.IdentificacionProv.ToString();


                    ModalPopupExtender1.Show();

                    break;

                default:
                    break;
            }
        }


        //btn Guardar del modal
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcionEdit.Text)
                && !string.IsNullOrEmpty(txtCantidadEdit.Text)
                && !ddlCategoriaEdit.SelectedValue.Equals("-1")
                && !ddlProveedorEdit.SelectedValue.Equals("-1"))
            {


                NHProducto producto = new NHProducto();
                producto.Codigo = int.Parse(txtId.Text);
                producto.CodigoCat = int.Parse(ddlCategoriaEdit.SelectedValue);
                producto.IdentificacionProv = int.Parse(ddlProveedorEdit.SelectedValue);
                producto.Valor = int.Parse(txtValorEdit.Text);
                producto.Descripcion = txtDescripcionEdit.Text;
                producto.Cantidad = int.Parse(txtCantidadEdit.Text);

                string result = Parcial.Logica.ClasesNH.clsNHProducto.UpdateProducto(producto.Codigo, producto);

                Response.Write("<script>alert('" + result + "')</script>");

                BindGrid();
            }
            else
            {
                Response.Write("<script>alert('Falta Informacion')</script>");
            }
        }


        //Eliminar del Modal
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string result = Parcial.Logica.ClasesNH.clsNHProducto.DeleteMembresia(int.Parse(txtId.Text));

            Response.Write("<script>alert('" + result + "')</script>");

            BindGrid();
        }

        //Cambio de pagina en el GridView
        protected void gridCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProducto.PageIndex = e.NewPageIndex;
            BindGrid();

        }
        
        //Buscar producto por filtro
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Logica.ClasesEntity.ENProducto.filtroProducto(ref gridProducto,int.Parse(ddlProveedorBuscar.SelectedValue),int.Parse(ddlCategoriaBuscar.SelectedValue));
        }


        //=========  METODOS  ==========================================



        /// <summary>
        /// Llena el Grid desde de la base de Datos
        /// </summary>
        public void BindGrid()
        {
            gridProducto.DataSource = Logica.ClasesNH.clsNHProducto.ConsultarProductos();
            gridProducto.DataBind();
        }

        /// <summary>
        /// Llena el formulario con valores por defecto
        /// </summary>
        public void fillForm()
        {
            Logica.ClasesNH.clsNHCategoria.fillDropDownConCategorias(ref ddlCategoria);
            Logica.ClasesNH.clsNHProveedor.fillDropDownConProveedores(ref ddlProveedor);


            Logica.ClasesNH.clsNHCategoria.fillDropDownConCategorias(ref ddlCategoriaBuscar);
            Logica.ClasesNH.clsNHProveedor.fillDropDownConProveedores(ref ddlProveedorBuscar);


            txtCantidad.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtValor.Text = string.Empty;


            BindGrid();
        }

      
    }
}
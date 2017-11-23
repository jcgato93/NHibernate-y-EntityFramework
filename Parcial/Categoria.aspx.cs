using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial
{
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Parcial.Logica.ModelNH.NHCategoria categoria = new Logica.ModelNH.NHCategoria();

            categoria.Descripcion = txtCatDescripcion.Text;

            string result = Parcial.Logica.ClasesNH.clsNHCategoria.InsertCategoria(categoria);

            Response.Write("<script>alert('" + result + "')</script>");

            txtCatDescripcion.Text = string.Empty;

            BindGrid();
        }


        //Row Command
        protected void gridCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "Details":

                    txtId.Text = gridCategorias.Rows[index].Cells[1].Text;
                    Parcial.Logica.ModelNH.NHCategoria categoria = Parcial.Logica.ClasesNH.clsNHCategoria.ConsultarCategorias(int.Parse(txtId.Text));

                    txtDescripcionEdit.Text = categoria.Descripcion;
                    ModalPopupExtender1.Show();

                    break;

                default:
                    break;
            }
        }


        //btn Guardar del modal
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcionEdit.Text))
            {
                Parcial.Logica.ModelNH.NHCategoria categoria = new Logica.ModelNH.NHCategoria();

                categoria.Codigo = int.Parse(txtId.Text);
                categoria.Descripcion = txtDescripcionEdit.Text;

                string result = Parcial.Logica.ClasesNH.clsNHCategoria.UpdateCategoria(categoria);

                Response.Write("<script>alert('" + result + "')</script>");

                BindGrid();
            }
            else
            {
                Response.Write("<script>alert('Falta la Descripcion')</script>");
            }
        }


        //Eliminar del Modal
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string result = Parcial.Logica.ClasesNH.clsNHCategoria.DeleteCategoria(int.Parse(txtId.Text));

            Response.Write("<script>alert('" + result + "')</script>");

            BindGrid();
        }

        //Cambio de pagina en el GridView
        protected void gridCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCategorias.PageIndex = e.NewPageIndex;
            BindGrid();

        }

        //=========  METODOS  ==========================================



        /// <summary>
        /// Llena el Grid desde de la base de Datos
        /// </summary>
        public void BindGrid()
        {
            gridCategorias.DataSource = Logica.ClasesNH.clsNHCategoria.ConsultarCategorias();
            gridCategorias.DataBind();
        }
    }
}
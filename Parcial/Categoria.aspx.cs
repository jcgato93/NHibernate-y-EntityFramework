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

           string result= Parcial.Logica.ClasesNH.clsNHCategoria.InsertCategoria(categoria);

            Response.Write("<script>alert('"+result+"')</script>");

            BindGrid();
        }



        //=========methods
        public void BindGrid()
        {
            gridCategorias.DataSource=Logica.ClasesNH.clsNHCategoria.ConsultarCategorias();
            gridCategorias.DataBind();
         }

    }
}
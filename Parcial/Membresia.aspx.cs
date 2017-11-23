using Parcial.Logica.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial
{
    public partial class Membresia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        //inserta
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            tbMembresia membresia = new tbMembresia();
            membresia.membDescripcion = txtDescripcion.Text;
            membresia.membCantidad = int.Parse(txtCantidad.Text);

            string result = Parcial.Logica.ClasesEntity.ENMembresia.InsertMembresia(membresia);

            Response.Write("<script>alert('" + result + "')</script>");

            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            BindGrid();
        }


        //Row Command
        protected void gridCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "Details":

                    txtId.Text = gridMembresia.Rows[index].Cells[1].Text;
                    Parcial.Logica.ModelEntity.tbMembresia membresia = Parcial.Logica.ClasesEntity.ENMembresia.getMembresiaPorId(int.Parse(txtId.Text));

                    //Re-set controlls
                    txtDescripcionEdit.Text = membresia.membDescripcion;
                    txtCantidadEdit.Text = membresia.membCantidad.ToString();

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
                && !string.IsNullOrEmpty(txtCantidad.Text))
            {


                tbMembresia membresia = new tbMembresia();
                membresia.membCodigo = int.Parse(txtId.Text);
                membresia.membDescripcion = txtDescripcionEdit.Text;
                membresia.membCantidad = int.Parse(txtCantidadEdit.Text);

                string result = Parcial.Logica.ClasesEntity.ENMembresia.UpdateMembresia(membresia.membCodigo, membresia);

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
            string result = Parcial.Logica.ClasesEntity.ENMembresia.DeleteMembresia(int.Parse(txtId.Text));

            Response.Write("<script>alert('" + result + "')</script>");

            BindGrid();
        }

        //Cambio de pagina en el GridView
        protected void gridCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridMembresia.PageIndex = e.NewPageIndex;
            BindGrid();

        }

        //=========  METODOS  ==========================================



        /// <summary>
        /// Llena el Grid desde de la base de Datos
        /// </summary>
        public void BindGrid()
        {
            gridMembresia.DataSource = Logica.ClasesEntity.ENMembresia.getMembresia();
            gridMembresia.DataBind();
        }
    }
}
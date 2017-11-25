using Parcial.Logica.ModelNH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial
{
    public partial class Proveedor : System.Web.UI.Page
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
            if (!ddlMembresia.SelectedValue.Equals("-1") )
            {
                NHProveedor proveedor = new NHProveedor();

                proveedor.Apellidos = txtApellidos.Text;
                proveedor.Nombres = txtNombres.Text;
                proveedor.CodigoMemb = int.Parse(ddlMembresia.SelectedValue);
                proveedor.Correo = txtCorreo.Text;
                proveedor.Direccion = txtDireccion.Text;
                proveedor.Telefono = txtTelefono.Text;
                


                string result = Parcial.Logica.ClasesNH.clsNHProveedor.InsertProveedor(proveedor);

                Response.Write("<script>alert('" + result + "')</script>");

                fillForm();
            }
            else
            {
                Response.Write("<script>alert('Seleccione la Membresia')</script>");
            }
        }


        //Row Command
        protected void gridCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "Details":

                    txtId.Text = gridProveedor.Rows[index].Cells[1].Text;
                    Parcial.Logica.ClasesEntity.ENMembresia.fillDropDownConMembresias(ref ddlMembresiaEdit);
                    

                    NHProveedor p = Parcial.Logica.ClasesNH.clsNHProveedor.ConsultarProveedorPorCodigo(int.Parse(txtId.Text));

                    //Re-set controlls
                    txtApellidosEdit.Text = p.Apellidos;
                    txtNombresEdit.Text = p.Nombres;
                    ddlMembresia.SelectedValue = p.CodigoMemb.ToString();
                    txtCorreoEdit.Text = p.Correo;
                    txtDireccionEdit.Text = p.Direccion;
                    txtTelefonoEdit.Text = p.Telefono;

                    ModalPopupExtender1.Show();

                    break;

                default:
                    break;
            }
        }


        //btn Guardar del modal
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtApellidosEdit.Text)
                && !string.IsNullOrEmpty(txtNombresEdit.Text)
                && !ddlMembresiaEdit.SelectedValue.Equals("-1")
                && !string.IsNullOrEmpty(txtCorreoEdit.Text)
                && !string.IsNullOrEmpty(txtDireccionEdit.Text)
                && !string.IsNullOrEmpty(txtTelefonoEdit.Text))
            {


                NHProveedor proveedor = new NHProveedor();
                proveedor.Identificacion = int.Parse(txtId.Text);
                proveedor.Apellidos = txtApellidosEdit.Text;
                proveedor.Nombres = txtNombresEdit.Text;
                proveedor.CodigoMemb = int.Parse(ddlMembresiaEdit.SelectedValue);
                proveedor.Correo = txtCorreoEdit.Text;
                proveedor.Direccion = txtDireccionEdit.Text;
                proveedor.Telefono = txtTelefonoEdit.Text;

                string result = Parcial.Logica.ClasesNH.clsNHProveedor.UpdateProveedor(int.Parse(txtId.Text), proveedor);

                Response.Write("<script>alert('" + result + "')</script>");

                fillForm();
            }
            else
            {
                Response.Write("<script>alert('Falta Informacion')</script>");
            }
        }


        //Eliminar del Modal
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string result = Parcial.Logica.ClasesNH.clsNHProveedor.DeleteProveedor(int.Parse(txtId.Text));

            Response.Write("<script>alert('" + result + "')</script>");

            fillForm();
        }

        //Cambio de pagina en el GridView
        protected void gridCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProveedor.PageIndex = e.NewPageIndex;
            BindGrid();

        }

        //=========  METODOS  ==========================================



        /// <summary>
        /// Llena el Grid desde de la base de Datos
        /// </summary>
        public void BindGrid()
        {
            gridProveedor.DataSource = Logica.ClasesNH.clsNHProveedor.ConsultarProveedores();
            gridProveedor.DataBind();
        }

        /// <summary>
        /// Llena el formulario con valores por defecto
        /// </summary>
        public void fillForm()
        {
            Parcial.Logica.ClasesEntity.ENMembresia.fillDropDownConMembresias(ref ddlMembresia);

            txtApellidos.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;


            BindGrid();
        }
    }
}
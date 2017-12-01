using Parcial.Logica.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Parcial.Logica.ClasesEntity
{
    public static class ENProducto
    {
        static ParcialEntities con = new ParcialEntities();



        /// <summary>
        /// LLena un GridView con los productos , segun 
        /// los parametros de filtro
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="CodigoProveedor"></param>
        /// <param name="CodigoCategoria"></param>
        public static void filtroProducto(ref GridView grid,int CodigoProveedor=-1,int CodigoCategoria=-1)
        {

            if (CodigoProveedor != -1 && CodigoCategoria != -1)
            {
                var producto = (from p in con.tbProducto
                                where p.provIdentificacion == CodigoProveedor && p.cateCodigo == CodigoCategoria
                                select p).ToList();

                grid.DataSource = producto;
                grid.DataBind();
            }
            else if (CodigoProveedor != -1 && CodigoCategoria == -1)
            {
                var producto = (from p in con.tbProducto
                                where p.provIdentificacion == CodigoProveedor
                                select p).ToList();

                grid.DataSource = producto;
                grid.DataBind();
            }
            else if (CodigoProveedor == -1 && CodigoCategoria != -1)
            {
                var producto = (from p in con.tbProducto
                                where p.cateCodigo == CodigoCategoria
                                select p).ToList();

                grid.DataSource = producto;
                grid.DataBind();
            }
            else if(CodigoProveedor == -1 && CodigoCategoria == -1)
            {
                var producto = (from p in con.tbProducto                                
                                select p).ToList();

                grid.DataSource = producto;
                grid.DataBind();
            }
            


        }


    }
}

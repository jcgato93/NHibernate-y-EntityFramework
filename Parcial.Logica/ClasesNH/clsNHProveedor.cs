using NHibernate;
using NHibernate.Cfg;
using Parcial.Logica.ModelNH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Parcial.Logica.ClasesNH
{
    public static class clsNHProveedor
    {
        static ISessionFactory mySessionFactory;
        static ISession mySession;

        static clsNHProveedor()
        {
            Configuration cfg = new Configuration();
            cfg.AddAssembly("Parcial.Logica");

            mySessionFactory = cfg.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();
        }


        /// <summary>
        /// Inserta un Proveedor
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        public static string InsertProveedor(NHProveedor proveedor)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHProveedor prov = new NHProveedor();

                    prov.CodigoMemb = proveedor.CodigoMemb;
                    prov.Apellidos = proveedor.Apellidos;
                    prov.Correo = proveedor.Correo;
                    prov.Direccion = proveedor.Direccion;
                    prov.Nombres = proveedor.Nombres;
                    prov.Telefono = proveedor.Telefono;                     
                    

                    mySession.Save(prov);
                    mySession.Transaction.Commit();
                    result = "Operacion Exitosa";
                }
            }
            catch (Exception ex)
            {
                result = "Fallo la operacion";
                throw ex;
            }

            return result;
        }


       /// <summary>
       /// Actuliza un proveedor
       /// </summary>
       /// <param name="producto"></param>
       /// <returns></returns>
        public static string UpdateProveedor(int provCodigo,NHProveedor proveedor)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHProveedor prov = (NHProveedor)mySession.Load(typeof(NHProveedor), Convert.ToInt32(provCodigo));
                    prov.CodigoMemb = proveedor.CodigoMemb;
                    prov.Apellidos = proveedor.Apellidos;
                    prov.Correo = proveedor.Correo;
                    prov.Direccion = proveedor.Direccion;
                    prov.Nombres = proveedor.Nombres;
                    prov.Telefono = proveedor.Telefono;

                    mySession.Update(prov);
                    mySession.Transaction.Commit();
                    result = "Operacion Exitosa";
                }
            }
            catch (Exception ex)
            {
                result = "Fallo la Operacion";
                throw ex;
            }

            return result;
        }


   /// <summary>
   /// Elimina un proveedor
   /// </summary>
   /// <param name="prodCodigo"></param>
   /// <returns></returns>
        public static string DeleteProveedor(int provIdentificacion)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHProveedor prov = (NHProveedor)mySession.Load(typeof(NHProveedor), Convert.ToInt32(provIdentificacion));
                    mySession.Delete(prov);
                    mySession.Transaction.Commit();
                    result = "Operacion Exitosa";
                }
            }
            catch (Exception ex)
            {
                result = "Fallo la Operacion";
                throw ex;
            }

            return result;
        }


     /// <summary>
     /// Retorna la lista de proveedores
     /// </summary>
     /// <returns></returns>
        public static IList ConsultarProveedores()
        {
            try
            {
                IList prov = mySession.CreateCriteria(typeof(NHProveedor)).List();
                return prov;
            }
            catch (Exception ex) { throw ex; }
        }


        /// <summary>
        /// LLena un DropDownList con el listado de proveedores
        /// </summary>
        /// <param name="ddl"></param>
        public static void fillDropDownConProveedores(ref DropDownList ddl)
        {
            try
            {
                IList categoria = mySession.CreateCriteria(typeof(NHProveedor)).List();                

                ddl.DataSource = categoria;
                ddl.DataTextField = "Nombres";
                ddl.DataValueField = "Identificacion";
                ddl.DataBind();

                ddl.Items.Insert(0,new ListItem("Todos", "-1"));
            }
            catch (Exception ex) { throw ex; }

        }


        /// <summary>
        /// Obtener proveedor por codigo
        /// </summary>
        /// <param name="provCodigo"></param>
        /// <returns></returns>
        public static NHProveedor ConsultarProveedorPorCodigo(int provCodigo)
        {

            try
            {
                NHProveedor prov = (NHProveedor)mySession.Load(typeof(NHProveedor), Convert.ToInt32(provCodigo));
                return prov;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}

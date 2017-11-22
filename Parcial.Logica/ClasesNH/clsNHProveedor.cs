using NHibernate;
using NHibernate.Cfg;
using Parcial.Logica.ModelNH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    NHProveedor prov = new NHProveedor
                    {
                        CodigoMemb = proveedor.CodigoMemb,
                        Apellidos=proveedor.Apellidos,
                        Correo=proveedor.Correo,
                        Direccion=proveedor.Direccion,
                        Nombres=proveedor.Nombres,
                        Telefono=proveedor.Telefono
                     
                    };

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
        public static string UpdateProveedor(NHProveedor proveedor)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHProveedor prov = (NHProveedor)mySession.Load(typeof(NHProveedor), Convert.ToInt64(proveedor.Identificacion));
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
                    NHProveedor prov = (NHProveedor)mySession.Load(typeof(NHProveedor), Convert.ToInt64(provIdentificacion));
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

    }
}

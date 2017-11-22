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
    public static class clsNHMembresia
    {
        static ISessionFactory mySessionFactory;
        static ISession mySession;

        static clsNHMembresia()
        {
            Configuration cfg = new Configuration();
            cfg.AddAssembly("Parcial.Logica");

            mySessionFactory = cfg.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();
        }


        /// <summary>
        /// Inserta una Membresia
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public static string InsertMembresia(NHMembresia membresia)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHMembresia memb = new NHMembresia
                    {
                       Cantidad = membresia.Cantidad,
                       Descripcion=membresia.Descripcion
                    };

                    mySession.Save(memb);
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
        /// Actualiza Una Membresia
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public static string UpdateMembresia(NHMembresia membresia)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHMembresia memb = (NHMembresia)mySession.Load(typeof(NHMembresia), Convert.ToInt64(membresia.Codigo));

                    memb.Cantidad = membresia.Cantidad;
                    memb.Descripcion = membresia.Descripcion;

                    mySession.Update(memb);
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
        /// Borra una Membresia
        /// </summary>
        /// <param name="cateCodigo"></param>
        /// <returns></returns>
        public static string DeleteMembresia(int membCodigo)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHMembresia memb = (NHMembresia)mySession.Load(typeof(NHMembresia), Convert.ToInt64(membCodigo));
                    mySession.Delete(memb);
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
        /// Retorna Un Listado de todas las 
        /// Membresias
        /// </summary>
        /// <returns></returns>
        public static IList ConsultarMembresias()
        {
            try
            {
                IList categoria = mySession.CreateCriteria(typeof(NHMembresia)).List();
                return categoria;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}

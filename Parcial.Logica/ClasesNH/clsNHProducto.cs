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
    public static class clsNHProducto
    {
        static ISessionFactory mySessionFactory;
        static ISession mySession;

        static clsNHProducto()
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
        public static string InsertProducto(NHProducto producto)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHProducto prod = new NHProducto
                    {
                        CodigoCat = producto.CodigoCat,
                        Cantidad= producto.Cantidad,
                        Descripcion=producto.Descripcion,
                        Valor=producto.Valor,
                        IdentificacionProv=producto.IdentificacionProv
                    };

                    mySession.Save(prod);
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
        public static string UpdateProducto(int prodCodigo,NHProducto producto)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHProducto prod = (NHProducto)mySession.Load(typeof(NHProducto), Convert.ToInt32(prodCodigo));
                    prod.CodigoCat = producto.CodigoCat;
                    prod.Cantidad = producto.Cantidad;
                    prod.Descripcion = producto.Descripcion;
                    prod.Valor = producto.Valor;
                    prod.IdentificacionProv = producto.IdentificacionProv;

                    mySession.Update(prod);
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
        public static string DeleteMembresia(int prodCodigo)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHProducto prod = (NHProducto)mySession.Load(typeof(NHProducto), Convert.ToInt32(prodCodigo));
                    mySession.Delete(prod);
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
        public static IList ConsultarProductos()
        {
            try
            {
                IList productos = mySession.CreateCriteria(typeof(NHProducto)).List();
                return productos;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Retorna un Producto por codigo
        /// </summary>
        /// <param name="prodCodigo"></param>
        /// <returns></returns>
        public static NHProducto ConsultarProductosPorCodigo(int prodCodigo)
        {
            try
            {
                NHProducto prod = (NHProducto)mySession.Load(typeof(NHProducto), Convert.ToInt32(prodCodigo));
                return prod;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Retorna un producto
        /// </summary>
        /// <param name="prodCodigo"></param>
        /// <returns></returns>
        public static NHProducto ConsultarCategorias(int prodCodigo)
        {

            try
            {
                NHProducto producto = (NHProducto)mySession.Load(typeof(NHProducto), Convert.ToInt32(prodCodigo));
                return producto;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}

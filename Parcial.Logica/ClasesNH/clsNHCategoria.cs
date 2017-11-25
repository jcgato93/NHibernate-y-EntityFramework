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
    public static class clsNHCategoria
    {
        static ISessionFactory mySessionFactory;
        static ISession mySession;

        static clsNHCategoria()
        {
            Configuration cfg = new Configuration();
            cfg.AddAssembly("Parcial.Logica");

            mySessionFactory = cfg.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();
        }


        /// <summary>
        /// Inserta una nueva Categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public static string InsertCategoria(NHCategoria categoria)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHCategoria cate = new NHCategoria
                    {
                        Descripcion = categoria.Descripcion
                    };

                    mySession.Save(cate);
                    mySession.Transaction.Commit();
                    result = "Operacion Exitosa";
                }
            }
            catch (Exception ex)
            {
                result= "Fallo la operacion";
                throw ex;
            }
          

            return result;
        }


        /// <summary>
        /// Actualiza Una categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public static string UpdateCategoria(NHCategoria categoria)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHCategoria cate = (NHCategoria)mySession.Load(typeof(NHCategoria), Convert.ToInt32(categoria.Codigo));

                    cate.Descripcion = categoria.Descripcion;

                    mySession.Update(cate);
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
        /// Borra una Categoria
        /// </summary>
        /// <param name="cateCodigo"></param>
        /// <returns></returns>
        public static string DeleteCategoria(int cateCodigo)
        {
            string result = "";
            try
            {
                using (mySession.BeginTransaction())
                {
                    NHCategoria cate = (NHCategoria)mySession.Load(typeof(NHCategoria), Convert.ToInt32(cateCodigo));
                    mySession.Delete(cate);
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
        /// Categorias
        /// </summary>
        /// <returns></returns>
        public static IList ConsultarCategorias()
        {
            try
            {
                IList categoria = mySession.CreateCriteria(typeof(NHCategoria)).List();
                return categoria;
            }
            catch (Exception ex) { throw ex; }
            
        }

        /// <summary>
        /// Retorna la informacion de una categoria por id
        /// </summary>
        /// <param name="cateCodigo"></param>
        /// <returns></returns>
        public static NHCategoria ConsultarCategorias(int cateCodigo)
        {
            
            try
            {
                NHCategoria categoria = (NHCategoria)mySession.Load(typeof(NHCategoria), Convert.ToInt32(cateCodigo));
                return categoria;
                
            }
            catch (Exception ex) { throw ex; }
         
        }


        /// <summary>
        /// Llena un DropDownList con el listado de las categorias         
        /// </summary>
        /// <param name="ddl"></param>
        public static void fillDropDownConCategorias(ref DropDownList ddl)
        {
            try
            {
                IList categoria = mySession.CreateCriteria(typeof(NHCategoria)).List();

                ddl.DataSource=categoria;
                ddl.DataTextField = "Descripcion";
                ddl.DataValueField = "Codigo";
                ddl.DataBind();

                ddl.Items.Insert(0,new ListItem("Todos","-1"));
            }
            catch (Exception ex) { throw ex; }

        }
    }
}

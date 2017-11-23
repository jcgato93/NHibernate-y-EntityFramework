using Parcial.Logica.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.Logica.ClasesEntity
{
    public static class ENMembresia
    {
        static ParcialEntities con = new ParcialEntities();


        /// <summary>
        /// Inserta una nueva membresia
        /// </summary>
        /// <param name="membresia"></param>
        /// <returns></returns>
        public static string InsertMembresia(tbMembresia membresia)
        {
            string result = "";
            try
            {
                tbMembresia memb = new tbMembresia();
                memb.membCantidad = membresia.membCantidad;
                memb.membDescripcion = membresia.membDescripcion;


                con.tbMembresia.Add(memb);
                con.SaveChanges();
                result = "Operacion Exitosa";
            }
            catch (Exception ex)
            {

                result = "Fallo de la Operacion";
            }

            return result;

        }

        
        /// <summary>
        /// Borra una Membresia
        /// </summary>
        /// <param name="membCodigo"></param>
        /// <returns></returns>
        public static string DeleteMembresia(int membCodigo)
        {
            string result = "";

            try
            {
                tbMembresia memb = (from tb in con.tbMembresia
                                    where tb.membCodigo == membCodigo
                                    select tb).First();




                con.tbMembresia.Remove(memb);
                con.SaveChanges();

                result = "Operacion Exitosa";
            }
            catch (Exception ex)
            {

                result = "Fallo de la Operacion";
            }
            return result;
        }


        /// <summary>
        /// Actuliza una membresia
        /// </summary>
        /// <param name="membCodigo"></param>
        /// <param name="membresia"></param>
        /// <returns></returns>
        public static string UpdateMembresia(int membCodigo,tbMembresia membresia)
        {
            string result = "";

            try
            {
                tbMembresia memb = (from tb in con.tbMembresia
                                    where tb.membCodigo == membCodigo
                                    select tb).First();


                memb.membCantidad = membresia.membCantidad;
                memb.membDescripcion = membresia.membDescripcion;


                con.SaveChanges();

                result = "Operacion Exitosa";
            }
            catch (Exception ex)
            {

                result = "Fallo de la Operacion";
            }
            return result;
        }


        /// <summary>
        /// Retorna la lista de todas las membresias
        /// </summary>
        /// <returns></returns>
        public static List<tbMembresia> getMembresia()
        {
            List<tbMembresia> list = new List<tbMembresia>();
            try
            {
                list = con.tbMembresia.ToList();

            }
            catch (Exception ex)
            {
                list = null;                
            }

            return list;
        }


        /// <summary>
        /// Retorna una membresia segun el codigo
        /// </summary>
        /// <param name="membCodigo"></param>
        /// <returns></returns>
        public static tbMembresia getMembresiaPorId(int membCodigo)
        {
            tbMembresia memb = new tbMembresia();
            try
            {
                memb = (from tb in con.tbMembresia
                        where tb.membCodigo == membCodigo
                        select tb).First();

            }
            catch (Exception ex)
            {
                memb = null;
            }

            return memb;
        }

    }
}

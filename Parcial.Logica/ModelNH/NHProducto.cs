using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.Logica.ModelNH
{
    public class NHProducto
    {
        public virtual int Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual double Valor { get; set; }
        public virtual int Identificacion { get; set; }
        public virtual int CodigoCat { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.Logica.ModelNH
{
    public class NHProveedor
    {
        [Key]
        public virtual int Identificacion { get; set; }
        public virtual string Nombres { get; set; }
        public virtual string Apellidos { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Correo { get; set; }
        public virtual int CodigoMemb { get; set; }
    }
}

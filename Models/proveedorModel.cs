using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("proveedor")]
    public class proveedorModel
    {
        [Key]
        public int id { get; set; }
        public int razon_social {get; set;}
        public int nombreComercial {get; set;}
        public int RUC {get; set;}
        public int dirección {get; set;}
        public int Celular {get; set;}
        public int Fijo {get; set;}
        public int Email {get; set;}
        public int id_Representante { get; set; }

        //[ForeignKey("id_Representante")]
        //public virtual representateModel Representate { get; set; }

    }
}

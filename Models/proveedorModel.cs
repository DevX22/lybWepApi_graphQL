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
        public string razonSocial {get; set;}
        public string nombreComercial {get; set;}
        [MaxLength(12)]
        public string ruc {get; set;}
        public string dirección {get; set;}
        [MaxLength(9)]
        public string Celular {get; set;}
        [MaxLength(9)]
        public string whatsApp { get; set; }
        [MaxLength(6)]
        public string Fijo {get; set;}
        public string correo {get; set;}
        public int id_representante { get; set; }
        public string representante { get; set; }

        [ForeignKey("id_representante")]
        public virtual personaModel? representate { get; set; }

    }
}

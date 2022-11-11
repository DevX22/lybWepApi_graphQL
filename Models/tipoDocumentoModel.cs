using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("tipoDocumento")]
    public class tipoDocumentoModel
    {
        [Key]
        public int id { get; set; }
        public byte maxCaracteres { get; set; }
        public string tipoDocumento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("tipoMedida")]
    public class tipoMedidaModel
    {
        [Key]
        public int id{ get; set; }
        public string tipoMedida { get; set; }
    }
}

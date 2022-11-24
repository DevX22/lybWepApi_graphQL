using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("adPage")]
    public class adPageModel
    {
        [Key]
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string imgUrl { get; set; }
    }
}

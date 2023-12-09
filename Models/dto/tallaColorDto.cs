using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class tallaColorDto
    {
        public int id { get; set; }
        public int id_talla { get; set; }
        public int? stock { get; set; }
        [MaxLength(50)]
        public string? colorName { get; set; }
        [MaxLength(8)]
        public string? colorCode { get; set; }
    }
}

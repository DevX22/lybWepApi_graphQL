using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class tallaProductoDto
    {
        public int id { get; set; }
        public int id_producto { get; set; }
        public int? stock { get; set; }
        public string? talla { get; set; }

        public virtual List<tallaColorDto>? colorTalla { get; set; }
    }
}

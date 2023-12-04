using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("domainUrl")]
    public class domainUrlModel
    {
        [Key]
        public int id { get; set; } = 100;
        public string? domain { get; set; }
        public string? imgDirectory { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("avatarPersona")]
    public class avatarModel
    {
        [Key]
        public int id { get; set; }
        public string nameImg { get; set; }
        public byte[] img { get; set; }
    }
}

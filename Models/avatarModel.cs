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
        public string nombreAvatar { get; set; }
        public string imgAvatar { get; set; }
    }
}

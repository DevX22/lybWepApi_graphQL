using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.err_Models
{
    [Table("err_back", Schema = "back")]
    public class err_BackModel
    {
        [Key]
        public long id { get; set; }
        public int id_user { get; set; }
        public string url { get; set; }
        public string controller { get; set; }
        public string ip { get; set; }
        public string method { get; set; }
        public string user_agent { get; set; }
        public string host { get; set; }
        public string class_component { get; set; }
        public string function_name { get; set; }
        public int line_number { get; set; }
        public string error { get; set; }
        public string StackTrace { get; set; }
        public bool status { get; set; }
        public string request { get; set; }
        public int error_code { get; set; }
        public DateTime dateCreate { get; set; }
    }
}

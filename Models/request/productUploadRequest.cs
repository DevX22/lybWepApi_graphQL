using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.request
{
    public class productUploadRequest
    {
        public string productoName  { get; set; }
        public string category {  get; set; }           
        public List<FormFile> imgs { get; set; }
    }
}

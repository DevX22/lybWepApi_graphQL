using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.response
{
    public class productUploadResponse
    {
        public List<imgProductoListDto> img {  get; set; }
    }

    public class imgProductoListDto
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}

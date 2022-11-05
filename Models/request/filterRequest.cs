using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.request
{
    public class filterRequest
    {
        public List<categoriaModel>? categorias { get; set; } = new();
        public bool? isOrderByAZ { get; set; } = false;
        public bool? isOrderByZA { get; set; } = false;
        public bool? isOrderByMenorMayor { get; set; } = false;
        public bool? isOrderByMayorMenor { get; set; } = false;

    }
}

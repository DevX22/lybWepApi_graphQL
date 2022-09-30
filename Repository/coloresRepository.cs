using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class coloresRepository<T> : genericRepository<T> where T : class
    {
    }
}

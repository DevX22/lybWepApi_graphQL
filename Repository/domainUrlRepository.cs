using Microsoft.EntityFrameworkCore;
using Models;
using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class domainUrlRepository : genericRepository<domainUrlModel>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<(string domain, string directory)> Get()
        {
            domainUrlModel domain= await _db.domainUrl.Where(x=>x.id==100).FirstOrDefaultAsync();
            if (domain==null)
            {
                throw new Exception("Error al obtener el dominio y el direcctory");
            }
            return (domain.domain, domain.imgDirectory);
        }
    }
}

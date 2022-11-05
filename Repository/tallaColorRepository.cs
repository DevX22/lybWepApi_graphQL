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
    public class tallaColorRepository<T> : genericRepository<T> where T : class
    {
        public virtual async Task<List<tallaColorModel>> GetByTallaIdAsync(int id)
        {
            try
            {
                List<tallaColorModel> res = await _db.tallaColor
                    .Where(x => x.id_talla == id && x.stock > 0).ToListAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

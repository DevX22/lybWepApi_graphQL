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
    public class colorProductoRepository<T> : genericRepository<T> where T : class
    {
        public virtual async Task<List<colorProductoModel>> GetByProductIdAsync(int id)
        {
            try
            {
                List<colorProductoModel> res = await _db.colorProducto
                    .Where(x => x.id_producto == id && x.stock > 0).ToListAsync();
                return res;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

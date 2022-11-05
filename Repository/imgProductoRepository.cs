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
    public class imgProductoRepository<T> : genericRepository<T> where T : class
    {
        public virtual async Task<List<imgProductoModel>> GetByProductIdAsync(int id)
        {
            try
            {
                List<imgProductoModel> res = await _db.imgProducto
                    .Where(x => x.id_producto == id).ToListAsync();
                return res;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

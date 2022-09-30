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
    public class inventarioProductoRepository<T> : genericRepository<T> where T : class
    {
        public async Task<inventarioModel> GetByProductAsync(int id)
        {
			try
			{
				inventarioModel res = await _db.inventario.Where(x => x.id_producto == id).FirstOrDefaultAsync();
				return res;
			}
			catch (Exception)
			{
				throw;
			}
        }

		public async Task<inventarioModel> InsertAsync(inventarioModel req)
		{
			try
			{
				_db.AddAsync(req);
				_db.SaveChangesAsync();
				return req;
			}
			catch (Exception)
			{
				throw;
			}
		} 
    }
}

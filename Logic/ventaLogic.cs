using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ventaLogic : ventaRepository
    {
        public async void saveNumeroComprobante(long id)
        {
			try
			{
				ventaModel src = await  GetByIdAsync(id);
				src.numeroComprobante=src.numeroComprobante + id.ToString();
				await UpdateAsync(src);
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}

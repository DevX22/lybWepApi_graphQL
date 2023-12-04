using Microsoft.EntityFrameworkCore;
using Models;
using Models.err_Models;
using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ventaRepository : genericRepository<ventaModel>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual async Task<List<ventaModel>> GetAllDetailedAsync()
        {
            try
            {
                //List<ventaModel> res = await _db.venta
                //    .Include(x=>x.Comprobante)
                //    .Include(x=>x.ProcesoVenta)
                //    .Include(x=>x.Pago).ToListAsync();
                List<ventaModel> res = await _db.venta.ToListAsync();
                return res;

            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al obtener toda la lista detallada Async", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }
    }
}

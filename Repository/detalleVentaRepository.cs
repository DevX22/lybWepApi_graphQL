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
    public class detalleVentaRepository : genericRepository<detalleVentaModel>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<detalleVentaModel>> GetAllByVentaIdAsync(int id)
        {
            try
            {
                List<detalleVentaModel> res = await _db.detalleVenta.Where(x=>x.id_producto==id).ToListAsync();
                return res;

            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al obtener la lista de detallas de un producto", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }

    }
}

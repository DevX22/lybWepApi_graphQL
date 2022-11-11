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
    public class err_BackRepository : genericRepository<err_BackModel>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<err_BackModel> errorByUser(int id)
        {
            try
            {
                List<err_BackModel> errores = _db.err_back.Where(x => x.id_user == id).ToList();
                return errores;
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al obtener lista de errores por usuario", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }

    }
}

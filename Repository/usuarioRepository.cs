using Microsoft.EntityFrameworkCore;
using Models;
using Models.request;
using Models.response;
using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Repository
{
    public class usuarioRepository : genericRepository<usuarioModel>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<usuarioModel>> listDetaildAsync()
        {
            List<usuarioModel> response = await _db.usuario
                .Include(x => x.persona)
                .Include(x => x.rolUser).ToListAsync();
            return response;
        }

        public async Task<bool> existsUsuarioAsync(string usser)
        {
            usser = usser.ToUpper();
            usuarioModel response = await _db.usuario.Where(x => x.usser == usser.Trim()).FirstOrDefaultAsync();
            if (response == null || response.usser == "")
            {
                return false;
            }
            return true;
        }
    }
}

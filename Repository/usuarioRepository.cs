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
    public class usuarioRepository : genericRepository<usuarioModel>, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<usuarioModel> listDetaild()
        {
            List<usuarioModel> response = _db.usuario
                .Include(x => x.persona)
                .Include(x => x.rolUser).ToList();
            return response;
        }

        public bool existsUsuario(string usser)
        {
            usuarioModel response = _db.usuario.Where(x => x.usser == usser.Trim()).FirstOrDefault();
            if (response == null || response.usser == "")
            {
                return false;
            }
            return true;
        }
    }
}

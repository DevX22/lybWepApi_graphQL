using Microsoft.AspNetCore.Http;
using Models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class uploadRepository
    {
        public async Task<uploadResponse> img(string rutaServer, IFormFile file)
        {
            try
            {
                uploadResponse rutaPublic = new();
                rutaPublic.url= rutaServer.Substring(2).Replace("\\", "/");

                using (FileStream stream = new FileStream(rutaServer, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return rutaPublic;

            }
            catch (Exception)
            {
                throw new Exception("Error al guardar la imagen: "+file.FileName );
            }
        }

        public async Task<bool> deleteImg(string ruta)
        {
            try
            {
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar imagen en la ruta: "+ruta);
            }
        }
    }
}

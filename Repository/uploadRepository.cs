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
    }
}

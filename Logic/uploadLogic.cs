using Microsoft.AspNetCore.Http;
using Models.request;
using Models.response;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tools;

namespace Logic
{
    public class uploadLogic
    {
		private readonly uploadRepository _up = new();
        private readonly domainUrlRepository _dom = new();
        private readonly imgProductoLogic _imgProducto = new();

        public async Task<uploadResponse> img(string category, IFormFile file)
        {
            try
            {
                string rutaServer = await directoryCreate(category);
                uploadResponse res = await uploadImg(rutaServer, file);
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Error al validar la imagen: " + file.FileName);
            }
        }
        public async Task<bool> deleteImg(deleteImgRequest req)
        {
            try
            {
                string ruta = "";
                (string dom, string directory) = await _dom.Get();
                directory = directory.Substring(0, 2)+req.url;
                ruta = directory + req.url.Replace("/", @"\");
                bool res = await _up.deleteImg(ruta);
                if(res==false)
                {
                    return false;
                }
                int delete = _imgProducto.Delete(req.id);
                if (delete == 0)
                {
                    return false;
                }
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<productUploadResponse> productImg(productUploadRequest req)
		{
			try
			{
                productUploadResponse res = new productUploadResponse();
                string rutaServer = "";
                if (req.imgs.Count > 0 && req.imgs.Count<8)
				{
                    req.productoName = textNormalized(req.productoName);
                    req.category = textNormalized(req.category);
                    rutaServer = await directoryCreate(categoryImgStatic.Producto,req.productoName,req.category);
                    List<imgProductoListDto> listImgDto = new();
                    foreach (var imgs in req.imgs)
                    {
                        imgProductoListDto imgDto = new();
                        var uri = await uploadImg(rutaServer, imgs);
                        imgDto.url = uri.url;
                        imgDto.name = Path.GetFileNameWithoutExtension(imgs.FileName);
                        listImgDto.Add(imgDto);
                    }
                    res.img = listImgDto;
                }
                else
                {
                    throw new Exception("La cantidad de archivos excede el maximo permitido");
                }
                return res; 
            }
			catch (Exception)
			{

				throw;
			}
		}

        private string textNormalized(string text)
        {
            text = text.Replace(' ', '_').ToLower();
            string normalized = text.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex(@"\p{Mn}", RegexOptions.Compiled);
            return regex.Replace(normalized, string.Empty);
        }

        private async Task<uploadResponse> uploadImg(string rutaServer,IFormFile img)
        {
            try
            {
                if (img == null || img.Length <= 0)
                {
                    throw new Exception("Debe subir una imagen");
                }
                byte[] buffer;
                if (img.Length > 5 * 1024 * 1024)
                {
                    throw new Exception($"La imagen excede el tamaño máximo permitido de 5Mb");
                }
                using (MemoryStream mStream = new MemoryStream())
                {
                    await img.CopyToAsync(mStream);
                    buffer = mStream.ToArray();
                }
                bool isImg = isFileImg(buffer);
                if (!isImg)
                {
                    throw new Exception("El archivo no es una imagen valida");
                }
                string ruta = Path.Combine(rutaServer + img.FileName);
                return await _up.img(ruta, img);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<string> directoryCreate(string Category,string fileOptional = null,string category=null)
        {
            try
            {
                (string dom, string directory) = await _dom.Get();
                if(fileOptional == null&&category==null)
                {
                    switch (Category)
                    {
                        case categoryImgStatic.Avatar:
                            directory = $"{directory}\\avatar\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                        case categoryImgStatic.Client:
                            directory = $"{directory}\\client\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                        case categoryImgStatic.User:
                            directory = $"{directory}\\user\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                        case categoryImgStatic.Producto:
                            directory = $"{directory}\\producto\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                        default:
                            directory = $"{directory}\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                    }
                }
                else
                {
                    switch (Category)
                    {
                        case categoryImgStatic.Avatar:
                            directory = $"{directory}\\avatar\\{category}\\{fileOptional}\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                        case categoryImgStatic.Client:
                            directory = $"{directory}\\client\\{category}\\{fileOptional}\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                        case categoryImgStatic.User:
                            directory = $"{directory}\\user\\{category}\\{fileOptional}\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                        case categoryImgStatic.Producto:
                            directory = $"{directory}\\producto\\{category}\\{fileOptional}\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                        default:
                            directory = $"{directory}\\";
                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }
                            break;
                    }
                }
                string rutaServer = Path.Combine(directory, Guid.NewGuid().ToString() + "_");
                return rutaServer;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
		private bool isFileImg(byte[] buffer)
		{
			try
			{
				using(Image imge = Image.Load(buffer))
				{
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

    }
}

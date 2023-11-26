﻿using Microsoft.AspNetCore.Http;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Logic
{
    public class uploadLogic
    {
		private readonly uploadRepository _up = new();
        private readonly domainUrlRepository _dom = new();
        public async Task<string> img(string category, IFormFile file)
        {
            try
			{
                if (file == null || file.Length <= 0)
                {
                    throw new Exception("Debe subir una imagen");
                }
                byte[] buffer = new byte[8];
                bool esImg = isFileImg(buffer);
                (string dom,string directory) = await _dom.Get();
                string extension = Path.GetExtension(file.FileName);


                if (file.Length > 5 * 1024 * 1024)
				{
					throw new Exception($"La imagen excede el tamaño máximo permitido de 5Mb");
				}

				using (Stream stream = file.OpenReadStream())
				{
					stream.Read(buffer, 0, buffer.Length);
				}

				if (esImg)
				{
					throw new Exception("El archivo no es una imagen valida");
				}

				switch (category)
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

                string rutaServer = Path.Combine(directory, file.FileName, "_", Guid.NewGuid().ToString(), extension);

				return await _up.img(rutaServer, file,dom);

            }
			catch (Exception)
			{
				throw new Exception("Error al validar la imagen: "+file.FileName);
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

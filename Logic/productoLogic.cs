using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.dto;
using Models.mapperConfig;
using Repository;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class productoLogic : productoRepository<productoModel>
    {
        private readonly imgProductoLogic _dbImg = new imgProductoLogic();
        private readonly colorProductoLogic _dbColor = new colorProductoLogic();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<productoDto>> listAllAsync()
        {
            List<productoDto> res = await listFrontAsync();
            if(res != null)
            {
                foreach (productoDto producto  in res)
                {
                    producto.imgProducto = await _dbImg.GetByProductAsync(producto.id);
                    producto.colorProducto = await _dbColor.GetByProductAsync(producto.id);
                }
            }
            return res;
        }
    }
}

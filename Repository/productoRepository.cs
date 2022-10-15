using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
using Models.dto;
using Models.mapperConfig;
using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class productoRepository<T> : genericRepository<T> where T : class
    {
        private IMapper _map = mapper.Go();
        public async Task<List<productoDto>> listFrontAsync()
        {

            List<productoDto> res = _map.Map<List<productoDto>>(await _db.producto.ToListAsync());
            return res;
        }
    }
}

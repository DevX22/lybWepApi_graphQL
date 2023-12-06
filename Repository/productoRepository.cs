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
            try
            {
                List<productoDto> res = _map.Map<List<productoDto>>(await _db.producto.Where(x=>x.estado==true).ToListAsync());
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<productoDto> getByIdFrontAsync(int id)
        {
            try
            {
                productoDto res = _map.Map<productoDto>(await _db.producto.FindAsync(id));
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> updateStockMulti(List<detalleVentaModel> req)
        {
            //using (var transaction = await _db.Database.BeginTransactionAsync())
            //{

            //}
            try
            {
                foreach (var venta in req)
                {
                    productoModel producto = await _db.producto.FindAsync(venta.id_producto);
                    if (producto != null)
                    {
                        if (producto.stock >= venta.cantidad)
                        {
                            producto.stock -= venta.cantidad;
                            _db.producto.Update(producto);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}

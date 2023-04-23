using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Models;
using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class proveedorRepository<T> : genericRepository<T> where T : class
    {
        public async Task<List<proveedorModel>> listAsyncDetaild()
        {
            List<proveedorModel> res = _db.proveedor.Include(x=>x.representate).ToList();
            return res;
        }
        public async Task<proveedorModel> createAsyncCustom(proveedorModel req)
        {
            req.representante = req.representate.nombre + " " + req.representate.apellidoPaterno;
            await _db.proveedor.AddAsync(req);
            await _db.SaveChangesAsync();
            return req;
        }
        public async Task<proveedorModel> updateAsyncCustom(proveedorModel req)
        {
            req.representante = req.representate.nombre + " " + req.representate.apellidoPaterno;
            _db.proveedor.Update(req);
            await _db.SaveChangesAsync();
            return req;
        }
    }
}

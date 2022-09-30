using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;
using Repository.genericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class categoriaRepository<T> : genericRepository<T> where T : class
    {
        public async Task<categoriaModel> insertAsync(categoriaModel req)
        {
            _db.AddAsync(req);
            _db.SaveChangesAsync();
            return req;
        }
    }
}

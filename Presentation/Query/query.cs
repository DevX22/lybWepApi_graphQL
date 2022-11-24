using HotChocolate.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Data;
using UseFilteringAttribute = HotChocolate.Data.UseFilteringAttribute;
using UseSortingAttribute = HotChocolate.Data.UseSortingAttribute;

namespace Presentation.Query
{
    [Authorize]
    public class query
    {
        private readonly _dbContext _db = new();
        //[UseSelection]
        //[UseFiltering]
        //[UseSorting]
        public IEnumerable<productoModel> getAll() => _db.producto.Include(x=>x.Categoria);
        //public IQueryable<productoModel> getAll()
        //{
        //    return _db.producto;
        //}
    }
}

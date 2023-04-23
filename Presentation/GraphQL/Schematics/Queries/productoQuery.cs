using Logic;
using Microsoft.EntityFrameworkCore;
using Models.dto;
using Models.request;
using Presentation.GraphQL.Types;
using Repository.Data;

namespace Presentation.GraphQL.Schematics.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class productosQuery
    {
        private readonly productoLogic _logic = new();

        public async Task<List<productoDto>> Productos(filterRequest req)
        {
            List<productoDto> res = await _logic.listAllAsync(req);
            return res;
        }
    }
    [ExtendObjectType(typeof(Query))]
    public class productoQuery
    {
        private readonly productoLogic _logic = new();
        public async Task<productoDto> producto(int id)
        {
            productoDto res = await _logic.getByIdDetailAsync(id);
            return res;
        }
    }
}

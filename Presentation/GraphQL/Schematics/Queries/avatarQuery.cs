using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Data;

namespace Presentation.GraphQL.Schematics.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class avatarQuery
    {
        private readonly _dbContext _db = new();
        public async Task<avatarModel> avatarGetId(int id)
            => await _db.avatar.Where(x => x.id == id).FirstOrDefaultAsync();

        public async Task<List<avatarModel>> avatares()
            => await _db.avatar.ToListAsync();
    }
}

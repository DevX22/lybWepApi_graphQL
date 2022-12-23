using Models;
using Repository.Data;

namespace Presentation.GraphQL.Schematics.Mutations
{
    public class avatarMutation
    {
        private readonly _dbContext _db = new();
        public avatarModel Add(avatarModel req)
        {
            _db.Add(req);
            _db.SaveChanges();
            return req;
        }
    }
}

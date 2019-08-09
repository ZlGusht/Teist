using System.Linq;
using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class AlbumRepository : EfDeletableEntityRepository<Album>
    {
        public AlbumRepository(TeistDbContext context) : base(context)
        {

        }

        public Album GetByName(string name)
        {
            var all = this.All();
            return all.Where(e => e.Name == name).FirstOrDefault();
        }
    }
}

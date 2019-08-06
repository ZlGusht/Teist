using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class AlbumRepository : EfDeletableEntityRepository<Album>
    {
        public AlbumRepository(TeistDbContext context) : base(context)
        {

        }
    }
}

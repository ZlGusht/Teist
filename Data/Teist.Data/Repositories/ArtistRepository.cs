using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class ArtistRepository : EfDeletableEntityRepository<Artist>
    {
        public ArtistRepository(TeistDbContext context) : base(context)
        {

        }
    }
}

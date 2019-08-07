using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class ReviewRepository : EfDeletableEntityRepository<Review>
    {
        public ReviewRepository(TeistDbContext context) : base(context)
        {

        }
    }
}

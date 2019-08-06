using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    class ReviewRepository : EfDeletableEntityRepository<Review>
    {
        public ReviewRepository(TeistDbContext context) : base(context)
        {

        }
    }
}

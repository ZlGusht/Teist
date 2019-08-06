using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    class ChartRepository : EfDeletableEntityRepository<Chart>
    {
        public ChartRepository(TeistDbContext context) : base(context)
        {

        }
    }
}

using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class ChartRepository : EfDeletableEntityRepository<Chart>
    {
        public ChartRepository(TeistDbContext context) : base(context)
        {

        }
    }
}

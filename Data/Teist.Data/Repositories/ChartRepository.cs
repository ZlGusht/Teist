namespace Teist.Data.Repositories
{
    using Teist.Data.Models;

    public class ChartRepository : BaseRepository<Chart>
    {
        public ChartRepository(TeistDbContext Data)
            : base(Data) { }
    }
}

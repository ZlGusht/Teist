namespace Teist.Data.Repositories
{
    using Teist.Data.Models;

    public class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(TeistDbContext Data)
            : base(Data) { }
    }
}

namespace Teist.Data.Repositories
{
    using Teist.Data.Models;

    public class ArtistRepository : BaseRepository<Artist>
    {
        public ArtistRepository(TeistDbContext Data)
            : base(Data) { }
    }
}

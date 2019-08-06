using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class AlbumRepository: BaseRepository<Album>
    {
        public AlbumRepository(TeistDbContext Data)
            : base(Data) { }
    }
}

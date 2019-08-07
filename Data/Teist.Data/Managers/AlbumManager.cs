using Teist.Data.Repositories;

namespace Teist.Data.Managers
{
    public class AlbumManager
    {
        private readonly AlbumRepository repository;

        public AlbumManager(AlbumRepository repository)
        {
            this.repository = repository;
        }

        public void CreateAlbum()
        {

        }
    }
}

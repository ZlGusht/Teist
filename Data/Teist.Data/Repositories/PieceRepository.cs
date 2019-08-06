namespace Teist.Data.Repositories
{
    using Teist.Data.Models;

    public class PieceRepository : BaseRepository<Piece>
    {
        public PieceRepository(TeistDbContext Data)
            : base(Data) { }
    }
}

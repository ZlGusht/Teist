using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class PieceRepository : EfDeletableEntityRepository<Piece>
    {
        public PieceRepository(TeistDbContext context) : base(context)
        {

        }
    }
}

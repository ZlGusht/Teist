using System.Collections.Generic;
using System.Linq;
using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class PieceRepository : EfDeletableEntityRepository<Piece>
    {
        public PieceRepository(TeistDbContext context) : base(context)
        {

        }

        public IList<Piece> GetRange(IList<string> list)
        {
            var result = new List<Piece>();

            foreach (var name in list)
            {
                result.Add(this.GetByName(name));
            }

            return result;
        }

        public Piece GetByName(string name)
        {
            var all = this.All();
            return all.Where(e => e.Name == name).FirstOrDefault();
        }
    }
}

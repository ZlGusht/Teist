using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class ArtistRepository : EfDeletableEntityRepository<Artist>
    {
        public ArtistRepository(TeistDbContext context) : base(context)
        {

        }

        public IList<Artist> GetRange (IList<string> list)
        {
            var result = new List<Artist>();

            foreach (var name in list)
            {
                result.Add(this.GetByName(name));
            }

            return result;
        }

        public Artist GetByName(string name)
        {
            var all = this.All();
            return all.Where(e => e.Nickname == name).FirstOrDefault();
        }
    }
}

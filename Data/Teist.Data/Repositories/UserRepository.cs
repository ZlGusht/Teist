using System;
using System.Collections.Generic;
using System.Text;
using Teist.Data.Models;

namespace Teist.Data.Repositories
{
    public class UserRepository : EfDeletableEntityRepository<ApplicationUser>
    {
        public UserRepository(TeistDbContext context) : base(context)
        {
        }
    }
}

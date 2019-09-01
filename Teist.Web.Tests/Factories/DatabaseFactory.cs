using Microsoft.EntityFrameworkCore;
using System;
using Teist.Data;

namespace Teist.Web.Tests.Factories
{
    class DatabaseFactory
    {
        public static TeistDbContext CreateContext()
        {
            DbContextOptions<TeistDbContext> options = new DbContextOptionsBuilder<TeistDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new TeistDbContext(options);
        }
    }
}

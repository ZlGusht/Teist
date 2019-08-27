using Microsoft.EntityFrameworkCore;
using System;


namespace Teist.Services.Test.Factories
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

using NUnit.Framework;
using Teist.Common.Mapping;
using Teist.Data;
using Teist.Services.Tests.ClassFixtures;
using Teist.Services.Tests.Factories;

namespace Teist.Services.Tests
{
    class BaseTest
    {
        protected readonly TeistDbContext context;

        public BaseTest()
        {
            context = DatabaseFactory.CreateContext();
        }
    }
}

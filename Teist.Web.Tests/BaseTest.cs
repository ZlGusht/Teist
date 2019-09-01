using Teist.Data;
using Teist.Web.Tests.Factories;

namespace Teist.Web.Tests
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

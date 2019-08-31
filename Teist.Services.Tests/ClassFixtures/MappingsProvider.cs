using System;
using System.Collections.Generic;
using System.Text;
using Teist.Common.Mapping;

namespace Teist.Services.Tests.ClassFixtures
{
    class MappingsProvider
    {
        public MappingsProvider()
        {
            AutoMapperConfig.RegisterMappings();
        }
    }
}

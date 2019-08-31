using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teist.Common.Enums;
using Teist.Common.ViewModels;
using Teist.Data.Models;
using Teist.Data.Repositories;

namespace Teist.Services.Tests
{
    [TestFixture]
    class ArtistManagerTests : BaseTest
    {

        [Test]
        public async Task Create_WorksProperly()
        {
            var service = await this.CreateArtistService(new List<Artist>());
            var artist = new ArtistViewModel()
            {
                FirstName = "TestFirst",
                LastName = "TestLast",
                Nickname = "Test",
                Genre = Genre.Pop.ToString()
            };
            var created = service.Create(artist);
            Assert.True(context.Artists.Any(x => x.Nickname == artist.Nickname));
            Assert.AreEqual(created.FirstName, artist.FirstName);

        }

        [Test]
        public async Task GetAll_WorksProperly()
        {
            var artist1 = new Artist()
            {
                FirstName = "TestFirst",
                LastName = "TestLast",
                Nickname = "Test",
                Genre = Genre.Pop
            };
            var artist2 = new Artist()
            {
                FirstName = "TestFirst2",
                LastName = "TestLast2",
                Nickname = "Test2",
                Genre = Genre.Pop
            };

            var list = new List<Artist>();
            list.Add(artist1);
            list.Add(artist2);


            var repoMock = new Mock<ArtistRepository>(context);
            repoMock.Setup(r => r.All()).Returns(list.AsQueryable());

            var service = new ArtistManager(repoMock.Object);

            var all = service.GetAll().ToList();

            Assert.AreEqual(list, all);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[i].FirstName, all[i].FirstName);
            }
        }

        private async Task<ArtistManager> CreateArtistService(IEnumerable<Artist> testData)
        {
            await context.Artists.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var artistRepository = new ArtistRepository(context);
            var service = new ArtistManager(artistRepository);
            return service;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
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
using Teist.Services;
using Teist.Web.Controllers;

namespace Teist.Web.Tests
{
    [TestFixture]
    class ArtistControllerTests : BaseTest
    {
        public ArtistControllerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Get_WorksProperly()
        {
            var controller = await this.CreateControllerAsync(new List<Artist>());
            var artists = controller.Get();
            Assert.IsNotNull(artists.First());
        }

        [Test]
        public async Task Create_WorksProperly()
        {
            var controller = await this.CreateControllerAsync(new List<Artist>());
            var artist = new ArtistViewModel()
            {
                Nickname = "TestNickname"
            };
            artist.FirstName = "TestFirstName";
            artist.LastName = "TestLast";
            artist.Genre = Genre.Metal.ToString();
            var result2 = controller.Post(artist);
            Assert.That(result2.GetType() == typeof(OkResult));
        }

        public async Task<ArtistController> CreateControllerAsync(IEnumerable<Artist> testData)
        {
            await context.Artists.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var artistRepository = new ArtistRepository(context);
            var service = new ArtistManager(artistRepository);
            return new ArtistController(service);
        }
        private void AddData()
        {
            this.context.Artists.Add(new Artist()
            {
                Nickname = "Test"
            }
            );

            this.context.Pieces.Add(new Piece()
            {
                Name = "Test",
                Artist = this.context.Artists.Where(a => a.Nickname == "Test").FirstOrDefault(),
                PieceType = PieceType.AlbumPiece,
                Genre = Genre.Pop
            }
            );

            this.context.Users.Add(new ApplicationUser()
            {
                Email = "TestUserEmail@test.ts"
            });
        }
    }
}

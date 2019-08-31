using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teist.Common.Enums;
using Teist.Common.ViewModels;
using Teist.Data;
using Teist.Data.Models;
using Teist.Data.Repositories;

namespace Teist.Services.Tests
{
    [TestFixture]
    class AlbumManagerTests : BaseTest
    {
        public AlbumManagerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Create_WorksProperly()
        {
            var service = await this.CreateAlbumService(new List<Album>());
            var expected = new AlbumViewModel()
            {
                Name = "TestName",
                Genre = Genre.Pop.ToString(),
                Performer = "Test",
                Pieces = new List<string>()
            };
            var created = service.CreateAlbum(expected);
            Assert.AreEqual(expected.Name, created.Name);
        }

        [Test]
        public async Task Get_WorksProperly()
        {
            var service = await this.CreateAlbumService(new List<Album>());
            var expected = new AlbumViewModel()
            {
                Name = "TestName",
                Genre = Genre.Pop.ToString(),
                Performer = "Test",
                Pieces = new List<string>()
            };
            var created = service.CreateAlbum(expected);
            var given = service.Get("TestName");
            Assert.AreEqual(given.Name, created.Name);
        }

        [Test]
        public async Task Update_WorksProperly()
        {
            var service = await this.CreateAlbumService(new List<Album>());
            var expected = new AlbumViewModel()
            {
                Name = "TestName",
                Genre = Genre.Pop.ToString(),
                Performer = "Test",
                Pieces = new List<string>()
            };
            var created = service.CreateAlbum(expected);
            expected.Name = "TestNameUpdated";
            service.Update(created, expected);
            var given = service.Get("TestNameUpdated");
            Assert.IsNotNull(given);
        }

        [Test]
        public async Task Delete_WorksProperly()
        {
            var service = await this.CreateAlbumService(new List<Album>());
            var expected = new AlbumViewModel()
            {
                Name = "TestName",
                Genre = Genre.Pop.ToString(),
                Performer = "Test",
                Pieces = new List<string>()
            };
            var created = service.CreateAlbum(expected);
            service.Delete(created.Name);
        }

        private async Task<AlbumManager> CreateAlbumService(IEnumerable<Album> testData)
        {
            await context.Albums.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var albumRepository = new AlbumRepository(context);
            var artistRepository = new ArtistRepository(context);
            var pieceRepository = new PieceRepository(context);
            var service = new AlbumManager(albumRepository, artistRepository, pieceRepository);
            return service;
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
        }
    }
}

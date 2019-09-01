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
    class AlbumControllerTests : BaseTest
    {
        public AlbumControllerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Create_WorksProperly()
        {
            var controller = await this.CreateAlbumControllerAsync(new List<Album>());
            var album = new AlbumViewModel()
            {
                Name = "TestAlbum",
                Genre = Genre.Pop.ToString(),
                Performer = "Test",
                Pieces= new List<string>()
            };
            var result = controller.Post(album);
            Assert.IsInstanceOf(typeof(OkResult), result);
        }

        [Test]
        public async Task Get_WorksProperly()
        {
            var controller = await this.CreateAlbumControllerAsync(new List<Album>());
            var result = controller.Get();
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public async Task Put_WorksProperly()
        {
            var controller = await this.CreateAlbumControllerAsync(new List<Album>());
            var album = new AlbumViewModel()
            {
                Name = "TestAlbum123",
                Genre = Genre.Pop.ToString(),
                Performer = "Test",
                Pieces = new List<string>()
            };
            var result = controller.Put("TestAlbum", album);
            Assert.IsInstanceOf(typeof(OkResult), result);
        }

        [Test]
        public async Task Delete_WorksProperly()
        {
            var controller = await this.CreateAlbumControllerAsync(new List<Album>());
            controller.Delete("TestAlbum123");
            var result = controller.Get("TestAlbum123");
        }


        private async Task<AlbumController> CreateAlbumControllerAsync(IEnumerable<Album> testData)
        {
            await context.Albums.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var albumRepository = new AlbumRepository(context);
            var artistRepository = new ArtistRepository(context);
            var pieceRepository = new PieceRepository(context);
            var service = new AlbumManager(albumRepository, artistRepository, pieceRepository);
            return new AlbumController(service);
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

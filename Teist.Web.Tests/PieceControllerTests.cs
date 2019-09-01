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
    class PieceControllerTests : BaseTest
    {
        public PieceControllerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Create_WorksProperly()
        {
            var controller = await this.CreatePieceControllerAsync(new List<Piece>());
            var piece = new PieceViewModel()
            {
                Name = "TestPiece",
                Genre = Genre.Pop.ToString(),
                Performer = "Test",
                PieceType = PieceType.AlbumPiece.ToString()
            };
            var result = controller.Post(piece);
            Assert.AreEqual(typeof(OkResult), result.GetType());
        }

        [Test]
        public async Task Delete_WorksProperly()
        {
            var controller = await this.CreatePieceControllerAsync(new List<Piece>());
            controller.Delete("Test");
            var result = controller.Get();
            Assert.IsNull(result.Where(x => x.Name == "Test").FirstOrDefault());
        }
        private async Task<PieceController> CreatePieceControllerAsync(IEnumerable<Piece> testData)
        {
            await context.Pieces.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var artistRepository = new ArtistRepository(context);
            var pieceRepository = new PieceRepository(context);
            var service = new PieceManager(pieceRepository, artistRepository);
            return new PieceController(service);
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

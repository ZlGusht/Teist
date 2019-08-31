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
    class PieceManagerTests : BaseTest
    {
        public PieceManagerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Create_WorksProperly()
        {
            var service = await this.CreatePieceService(new List<Piece>());
            var expected = new PieceViewModel()
            {
                Name = "Test",
                Performer = "Test",
                PieceType = PieceType.AlbumPiece.ToString(),
                Genre = Genre.HipHop.ToString()
            };
            var created = service.Create(expected);
            Assert.AreEqual(created.Name, expected.Name);
        }

        [Test]
        public async Task Update_WorksProperly()
        {
            var service = await this.CreatePieceService(new List<Piece>());
            var expected = new PieceViewModel()
            {
                Name = "Test",
                Performer = "Test",
                PieceType = PieceType.AlbumPiece.ToString(),
                Genre = Genre.HipHop.ToString()
            };
            var created = service.Create(expected);
            expected.Name = "TestUpdated";
            service.Update(created.Name, expected);
            Assert.NotNull(service.GetAll().Where(x => x.Name == expected.Name));
        }

        private async Task<PieceManager> CreatePieceService(IEnumerable<Piece> testData)
        {
            await context.Pieces.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var artistRepository = new ArtistRepository(context);
            var pieceRepository = new PieceRepository(context);
            var service = new PieceManager(pieceRepository, artistRepository);
            return service;
        }

        private void AddData()

        {
            this.context.Artists.Add(new Artist()
            {
                Nickname = "Test"
            }
            );
        }
    }
}

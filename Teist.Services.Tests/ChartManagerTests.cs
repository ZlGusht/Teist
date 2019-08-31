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
    class ChartManagerTests : BaseTest
    {
        public ChartManagerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Create_WorksProperly()
        {
            var service = await this.CreateChartService(new List<Chart>());
            var expected = new ChartViewModel()
            {
                Name = "TestChart",
                Type = "Piece",
                Contents = new List<string>(),
                Description = "Amazing"
            };
            var created = service.Create(expected);
            Assert.AreEqual(created.Name, expected.Name);
        }


        [Test]
        public async Task All_WorksProperly()
        {
            var service = await this.CreateChartService(new List<Chart>());
            var chart1 = new ChartViewModel()
            {
                Name = "TestChart",
                Type = "Piece",
                Contents = new List<string>(),
                Description = "Amazing"
            };

            var chart2 = new ChartViewModel()
            {
                Name = "TestChart2",
                Type = "Piece",
                Contents = new List<string>(),
                Description = "Amazing2"
            };
            var created1 = service.Create(chart1);
            var created2 = service.Create(chart2);
            Assert.Contains(created1, service.All().ToList());
            Assert.Contains(created2, service.All().ToList());
        }
        private async Task<ChartManager> CreateChartService(IEnumerable<Chart> testData)
        {
            await context.Charts.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var chartRepository = new ChartRepository(context);
            var pieceRepository = new PieceRepository(context);
            var albumRepository = new AlbumRepository(context);
            var artistRepository = new ArtistRepository(context);
            var service = new ChartManager(chartRepository, albumRepository, pieceRepository, artistRepository);
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

            this.context.Users.Add(new ApplicationUser()
            {
                Email = "TestUserEmail@test.ts"
            });
        }
    }
}

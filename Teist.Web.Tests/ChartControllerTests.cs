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
    class ChartControllerTests : BaseTest
    {

        public ChartControllerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Create_WorksProperly()
        {
            var controller = await this.CreatChartControllerAsync(new List<Chart>());
            var chart = new ChartViewModel()
            {
                Name = "TestChart",
                Type = "Artist",
                Contents = new List<string>(),
                Description = "Wow!"
            };
            var result = controller.Post(chart);
            Assert.AreEqual(typeof(OkResult), result.GetType());
        }

        [Test]
        public async Task Get_WorksProperly()
        {
            var controller = await this.CreatChartControllerAsync(new List<Chart>());
            var result = controller.Get();
            Assert.NotNull(result.ToList()[0]);
        }


        private async Task<ChartController> CreatChartControllerAsync(IEnumerable<Chart> testData)
        {
            await context.Charts.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var albumRepository = new AlbumRepository(context);
            var chartRepository = new ChartRepository(context);
            var artistRepository = new ArtistRepository(context);
            var pieceRepository = new PieceRepository(context);
            var service = new ChartManager(chartRepository ,albumRepository, pieceRepository, artistRepository);
            return new ChartController(service);
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

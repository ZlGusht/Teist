using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    class ReviewControllerTests : BaseTest
    {
        public ReviewControllerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Get_WorksProperly()
        {
            var controller = await this.CreateReviewController(new List<Review>());
            var result = controller.Get();
            Assert.AreEqual(result.Count(), 1);
        }

        private async Task<ReviewController> CreateReviewController(IEnumerable<Review> testData)
        {
            await context.Reviews.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var reviewRepository = new ReviewRepository(context);
            var userRepository = new UserRepository(context);
            var pieceRepository = new PieceRepository(context);
            var albumRepository = new AlbumRepository(context);
            var artistRepository = new ArtistRepository(context);
            var service = new ReviewManager(reviewRepository, pieceRepository, albumRepository, artistRepository, userRepository);
            return new ReviewController(service);
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

            this.context.Reviews.Add(new Review()
            {
                Name = "Test"
            });
        }
    }
}

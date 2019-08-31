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

namespace Teist.Services.Tests
{
    [TestFixture]
    class ReviewManagerTests : BaseTest
    {
        public ReviewManagerTests()
        {
            this.AddData();
        }

        [Test]
        public async Task Create_WorksProperly()
        {
            var service = await this.CreateReviewService(new List<Review>());
            var expected = new ReviewViewModel()
            {
                Name = "TestReview",
                Description = "Amazing",
                Type = "Piece",
                Contents = "Test"
            };
            var principle = new Mock<ClaimsPrincipal>();
            principle.Setup(u => u.Identity.Name).Returns("TestUserEmail@test.ts");
            var created = service.Create(expected, principle.Object);
            Assert.AreEqual(expected.Name, created.Name);
        }

        [Test]
        public async Task All_WorksProperly()
        {
            var service = await this.CreateReviewService(new List<Review>());
            var review = new ReviewViewModel()
            {
                Name = "TestReview123",
                Description = "Amazing",
                Type = "Piece",
                Contents = "Test"
            };
            var principle = new Mock<ClaimsPrincipal>();
            principle.Setup(u => u.Identity.Name).Returns("TestUserEmail@test.ts");
            service.Create(review, principle.Object);
            Assert.IsNotNull(service.All().Where(x => x.Name == review.Name).FirstOrDefault());
        }

        private async Task<ReviewManager> CreateReviewService(IEnumerable<Review> testData)
        {
            await context.Reviews.AddRangeAsync(testData);
            await context.SaveChangesAsync();
            var reviewRepository = new ReviewRepository(context);
            var userRepository = new UserRepository(context);
            var pieceRepository = new PieceRepository(context);
            var albumRepository = new AlbumRepository(context);
            var artistRepository = new ArtistRepository(context);
            var service = new ReviewManager(reviewRepository, pieceRepository, albumRepository, artistRepository, userRepository);
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

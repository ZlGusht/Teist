using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Teist.Common.ViewModels;
using Teist.Data.Models;
using Teist.Data.Repositories;

namespace Teist.Data.Managers
{
    public class ReviewManager
    {
        private readonly ReviewRepository reviewRepository;
        private readonly PieceRepository pieceRepository;
        private readonly AlbumRepository albumRepository;
        private readonly ArtistRepository artistRepository;
        private readonly UserRepository userRepository;

        public ReviewManager(ReviewRepository reviewRepository, PieceRepository pieceRepository, AlbumRepository albumRepository, ArtistRepository artistRepository, UserRepository userRepository)
        {
            this.reviewRepository = reviewRepository;
            this.pieceRepository = pieceRepository;
            this.albumRepository = albumRepository;
            this.artistRepository = artistRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<Review> All()
        {
            return this.reviewRepository.All();
        }

        public void Create(ReviewViewModel model, ClaimsPrincipal principal)
        {
            var user = this.userRepository.All().Where(u => u.Email == principal.Identity.Name).FirstOrDefault();
            var review = new Review()
            {
                Name = model.Name,
                Reviewer = user,
                Description = model.Description,
            };

            switch (model.Type)
            {
                case "Album":
                    review.Album = this.albumRepository.GetByName(model.Contents);
                    break;
                case "Artist":
                    review.Artist = this.artistRepository.GetByName(model.Contents);
                    break;
                case "Piece":
                    review.Piece = this.pieceRepository.GetByName(model.Contents);
                    break;
            }

            this.reviewRepository.Add(review);
        }
    }
}

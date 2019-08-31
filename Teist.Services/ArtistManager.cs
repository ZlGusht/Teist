using System;
using System.Collections.Generic;
using Teist.Common.Enums;
using Teist.Common.ViewModels;
using Teist.Data.Models;
using Teist.Data.Repositories;

namespace Teist.Services
{
    public class ArtistManager
    {
        private readonly ArtistRepository artistRepository;

        public ArtistManager(ArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public Artist Create(ArtistViewModel model)
        {
            Object genre;
            Enum.TryParse(typeof(Genre), model.Genre, out genre);


            var artist = new Artist()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Nickname = model.Nickname,
                Genre = (Genre)genre

            };

            this.artistRepository.Add(artist);
            return artist;
        }

        public IEnumerable<Artist> GetAll()
        {
            return this.artistRepository.All();
        }
    }
}

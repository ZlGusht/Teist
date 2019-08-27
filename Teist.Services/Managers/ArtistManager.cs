using System;
using System.Collections.Generic;
using Teist.Common.Enums;
using Teist.Common.ViewModels;
using Teist.Data.Models;
using Teist.Data.Repositories;

namespace Teist.Services.Managers
{
    public class ArtistManager
    {
        private readonly ArtistRepository artistRepository;

        public ArtistManager(ArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public void Create(ArtistViewModel model)
        {
            Object genre;
            Enum.TryParse(typeof(Genre), model.Genre, out genre);


            var artist = new Artist()
            {
                Nickname = model.Nickname,
                Genre = (Genre)genre

            };

            if (model.FirstName != string.Empty)
            {
                artist.FirstName = model.FirstName;
            }

            if (model.LastName != string.Empty)
            {
                artist.LastName = model.LastName;
            }

            this.artistRepository.Add(artist);
        }

        public IEnumerable<Artist> GetAll()
        {
            return this.artistRepository.All();
        }
    }
}

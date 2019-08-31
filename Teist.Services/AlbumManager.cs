namespace Teist.Services
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;

    using Teist.Common.ViewModels;
    using Teist.Data.Models;
    using Teist.Data.Repositories;
    using Teist.Common.Enums;

    public class AlbumManager
    {
        private readonly AlbumRepository albumRepository;
        private readonly ArtistRepository artistRepository;
        private readonly PieceRepository pieceRepository;

        public AlbumManager(AlbumRepository albumRepository , ArtistRepository artistRepository, PieceRepository pieceRepository)
        {
            this.albumRepository = albumRepository;
            this.artistRepository = artistRepository;
            this.pieceRepository = pieceRepository;
        }

        public Album CreateAlbum(AlbumViewModel album)
        {
            Object Genre;

            Enum.TryParse(typeof(Genre), album.Genre, out Genre);
            var albumToCreate = new Album()
            {
                Name = album.Name,
                Genre = (Genre)Genre,
                Artist = this.artistRepository.GetByName(album.Performer),
                Pieces = this.pieceRepository.GetRange(album.Pieces),
            };

            this.albumRepository.Add(albumToCreate);
            return albumToCreate;
        }

        public IEnumerable<Album> GetAll()
        {
            return this.albumRepository.All();
        }

        public Album Get(string name)
        {
            return this.albumRepository.GetByName(name);
        }

        public Album Update(Album old, AlbumViewModel updated)
        {
            this.albumRepository.HardDelete(old);
            var created = this.CreateAlbum(updated);

            return created;
        }

        public void Delete(string name)
        {
            var album = this.Get(name);

            this.albumRepository.HardDelete(album);
        }
    }
}

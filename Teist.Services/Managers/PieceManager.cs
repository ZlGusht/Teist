using System;
using System.Collections.Generic;
using System.Text;
using Teist.Common.Enums;
using Teist.Common.ViewModels;
using Teist.Data.Models;
using Teist.Data.Repositories;

namespace Teist.Services.Managers
{
    public class PieceManager
    {
        private readonly PieceRepository pieceRepository;
        private readonly ArtistRepository artistRepository;

        public PieceManager(PieceRepository pieceRepository, ArtistRepository artistRepository)
        {
            this.pieceRepository = pieceRepository;
            this.artistRepository = artistRepository;
        }

        public void Create(PieceViewModel model)
        {
            Object pieceType;
            Object Genre;

            Enum.TryParse(typeof(PieceType), model.PieceType, out pieceType);
            Enum.TryParse(typeof(Genre), model.Genre, out Genre);

            var piece = new Piece()
            {
                Name = model.Name,
                Artist = this.artistRepository.GetByName(model.Performer),
                PieceType = (PieceType)pieceType,
                Genre = (Genre)Genre,
            };
            this.pieceRepository.Add(piece);
        }

        public IEnumerable<Piece> GetAll()
        {
            return this.pieceRepository.All();
        }

        public void Update(string id, PieceViewModel piece)
        {
            this.pieceRepository.HardDelete(this.pieceRepository.GetByName(id));
            this.Create(piece);
        }

        public void Delete(string id)
        {
            this.pieceRepository.Delete(this.pieceRepository.GetByName(id));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Teist.Common.Enums;
using Teist.Common.ViewModels;
using Teist.Data.Models;
using Teist.Data.Repositories;

namespace Teist.Data.Managers
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

            var collabs = new List<Artist>();

            foreach (var collab in model.Collaborators)
            {
                collabs.Add(this.artistRepository.GetByName(collab));
            }

            var piece = new Piece()
            {
                Name = model.Name,
                Performer = this.artistRepository.GetByName(model.Performer),
                PieceType = (PieceType)pieceType,
                Genre = (Genre)Genre,
                Collaborators = collabs,
            };
            this.pieceRepository.Add(piece);
        }

        public IEnumerable<Piece> GetAll()
        {
            return this.pieceRepository.All();
        }
    }
}

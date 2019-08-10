using System;
using System.Collections.Generic;
using System.Text;
using Teist.Common.ViewModels;
using Teist.Data.Models;
using Teist.Data.Repositories;

namespace Teist.Data.Managers
{
    public class ChartManager
    {
        private readonly ChartRepository chartRepository;
        private readonly AlbumRepository albumRepository;
        private readonly PieceRepository pieceRepository;
        private readonly ArtistRepository artistRepository;

        public ChartManager(ChartRepository chartRepository, AlbumRepository albumRepository, PieceRepository pieceRepository, ArtistRepository artistRepository)
        {
            this.chartRepository = chartRepository;
            this.albumRepository = albumRepository;
            this.pieceRepository = pieceRepository;
            this.artistRepository = artistRepository;
        }

        public void Create(ChartViewModel model)
        {
            var chart = new Chart()
            {
                Name = model.Name,
                Description = model.Description,
            };

            switch (model.Type)
            {
                case "Album":
                    var albums = new List<Album>();
                    foreach (var album in model.Contents)
                    {
                        albums.Add(this.albumRepository.GetByName(album));
                    };

                    chart.Albums = albums;

                    break;
                case "Artist":
                    var artists = new List<Artist>();
                    foreach (var artist in model.Contents)
                    {
                        artists.Add(this.artistRepository.GetByName(artist));
                    };

                    chart.Artists = artists;

                    break;
                case "Piece":
                    var pieces = new List<Piece>();
                    foreach (var piece in model.Contents)
                    {
                        pieces.Add(this.pieceRepository.GetByName(piece));
                    };

                    chart.Pieces = pieces;

                    break;
            }

            this.chartRepository.Add(chart);
        }
    }
}

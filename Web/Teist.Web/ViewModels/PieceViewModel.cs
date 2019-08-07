using System.ComponentModel.DataAnnotations;
using Teist.Common.Enums;

namespace Teist.Web.ViewModels
{
    public class PieceViewModel
    {
        [Required]
        public ArtistViewModel Performer { get; set; }

        public AlbumViewModel Album { get; set; }

        [Required]
        public PieceType PieceType { get; set; }

        public ChartViewModel Chart { get; set; }
    }
}

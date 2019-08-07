using System.ComponentModel.DataAnnotations;
using Teist.Data.Models;

namespace Teist.Web.ViewModels
{
    public class AlbumViewModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public ArtistViewModel Performer { get; set; }
    }
}

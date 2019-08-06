using System.ComponentModel.DataAnnotations;

namespace Teist.Web.ViewModels
{
    public class ArtistViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Nickname { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

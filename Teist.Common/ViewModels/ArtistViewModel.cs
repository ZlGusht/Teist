namespace Teist.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Teist.Common.Enums;

    public class ArtistViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Nickname { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Genre { get; set; }
    }
}

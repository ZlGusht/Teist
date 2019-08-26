namespace Teist.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Teist.Common.Enums;

    public class ArtistViewModel
    {
        [Required]
        [MinLength(GlobalConstants.entityMinLength)]
        [MaxLength(GlobalConstants.entityMaxLength)]
        public string Nickname { get; set; }

        [Required]
        [MinLength(GlobalConstants.entityMinLength)]
        [MaxLength(GlobalConstants.entityMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstants.entityMinLength)]
        [MaxLength(GlobalConstants.entityMaxLength)]
        public string LastName { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}

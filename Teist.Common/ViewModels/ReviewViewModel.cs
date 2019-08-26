namespace Teist.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        [Required]
        [MinLength(GlobalConstants.entityMinLength)]
        [MaxLength(GlobalConstants.entityMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Contents { get; set; }
    }
}

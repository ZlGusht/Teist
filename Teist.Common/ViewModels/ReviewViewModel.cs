namespace Teist.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        [Required]
        public string Reviewer { get; set; }

        [Required]
        public string Description { get; set; }

        public string Piece { get; set; }

        public string Album { get; set; }
    }
}

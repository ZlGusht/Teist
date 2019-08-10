namespace Teist.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        [Required]
        public string Description { get; set; }

        public string Type { get; set; }

        public string Contents { get; set; }
    }
}

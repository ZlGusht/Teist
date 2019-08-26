namespace Teist.Common.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Teist.Common.Enums;

    public class AlbumViewModel
    {

        [Required]
        [MinLength(GlobalConstants.entityMinLength)]
        [MaxLength(GlobalConstants.entityMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Performer { get; set; }

        public IList<string> Pieces { get; set; }
    }
}

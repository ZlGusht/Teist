namespace Teist.Common.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Teist.Common.Enums;

    public class AlbumViewModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        public string Performer { get; set; }

        public IList<string> Pieces { get; set; }
    }
}

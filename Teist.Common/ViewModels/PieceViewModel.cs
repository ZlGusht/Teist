namespace Teist.Common.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Teist.Common.Enums;

    public class PieceViewModel
    {
        [Required]
        public string Performer { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PieceType { get; set; }

        public string Genre { get; set; }
    }
}

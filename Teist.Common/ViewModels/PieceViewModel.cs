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
        public IList<string> Collaborators { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public PieceType PieceType { get; set; }

        public string Chart { get; set; }
    }
}

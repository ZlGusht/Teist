namespace Teist.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Teist.Common.Enums;
    using Teist.Data.Common.Models;

    public class Piece : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Artist Performer { get; set; }

        public Album Album { get; set; }

        [Required]
        public PieceType PieceType { get; set; }

        public virtual IList<Review> Reviews { get; set; }

        public Chart Chart { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}

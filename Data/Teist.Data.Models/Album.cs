namespace Teist.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Teist.Common.Enums;
    using Teist.Data.Common.Models;

    public class Album : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public virtual IList<Piece> Pieces { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public virtual Artist Artist { get; set; }

        public virtual IList<Review> Reviews { get; set; }

        public virtual Chart Chart { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}

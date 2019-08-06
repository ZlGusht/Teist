namespace Teist.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Teist.Data.Common.Models;

    public class Album : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get ; set; }

        [Required]
        public IList<Piece> Pieces { get; set; }

        [Required]
        public Artist Performer { get; set; }

        public virtual IList<Artist> Collaborators { get; set; }

        public virtual IList<Review> Reviews { get; set; }

        public virtual IList<Chart> Charts { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}

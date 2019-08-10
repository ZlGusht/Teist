namespace Teist.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Teist.Data.Common.Models;

    public class Chart : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual IList<Piece> Pieces { get; set; }

        public virtual IList<Artist> Artists { get; set; }

        public virtual IList<Album> Albums { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}

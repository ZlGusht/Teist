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

        [Required]
        public virtual IList<Piece> Pieces { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}

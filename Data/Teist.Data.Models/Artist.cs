namespace Teist.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Teist.Common.Enums;
    using Teist.Data.Common.Models;

    public class Artist : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }

        public virtual IList<Album> Albums { get; set; }

        public virtual IList<Piece> Pieces { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}

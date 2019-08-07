namespace Teist.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Teist.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Reviewer { get; set; }

        public Piece Piece { get; set; }

        public Album Album { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}

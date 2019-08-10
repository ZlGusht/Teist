namespace Teist.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Teist.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Reviewer { get; set; }

        public virtual Piece Piece { get; set; }

        public virtual Album Album { get; set; }

        public virtual Artist Artist { get; set; }

        public string Description { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}

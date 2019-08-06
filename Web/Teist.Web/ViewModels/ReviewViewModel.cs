using System.ComponentModel.DataAnnotations;
using Teist.Data.Models;

namespace Teist.Web.ViewModels
{
    public class ReviewViewModel
    {
        [Required]
        public ApplicationUser Reviewer { get; set; }

        public Piece Piece { get; set; }

        public Album Album { get; set; }
    }
}

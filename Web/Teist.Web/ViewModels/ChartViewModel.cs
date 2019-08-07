using System.ComponentModel.DataAnnotations;

namespace Teist.Web.ViewModels
{
    public class ChartViewModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

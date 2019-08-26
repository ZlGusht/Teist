namespace Teist.Common.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ChartViewModel
    {

        [Required]
        [MinLength(GlobalConstants.entityMinLength)]
        [MaxLength(GlobalConstants.entityMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IList<string> Contents { get; set; }
    }
}

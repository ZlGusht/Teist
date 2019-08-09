namespace Teist.Common.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ChartViewModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public IList<string> Contents { get; set; }
    }
}

namespace WonderlandBooks.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Tag : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}

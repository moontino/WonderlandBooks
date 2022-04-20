namespace WonderlandBooks.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Shelf : BaseDeletableModel<int>
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ReadType ReadType { get; set; }
    }
}

namespace WonderlandBooks.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public int? ParentId { get; set; }

        public Comment Parent { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

namespace WonderlandBooks.Data.Models
{
    using WonderlandBooks.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

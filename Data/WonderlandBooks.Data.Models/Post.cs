using WonderlandBooks.Data.Common.Models;

namespace WonderlandBooks.Data.Models
{
    public class Post:BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }

    }
}

namespace WonderlandBooks.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Genre : BaseModel<int>
    {
        public Genre()
        {
            this.Books = new HashSet<Book>();
            this.Authors = new HashSet<Author>();
            this.Posts = new HashSet<Post>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}

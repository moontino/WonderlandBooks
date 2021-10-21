namespace WonderlandBooks.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Author : BaseModel<int>
    {
        public Author()
        {
            this.BookSeries = new HashSet<BookSeries>();
            this.Books = new HashSet<Book>();
            this.Genres = new HashSet<Genre>();
        }

        [Required]
        public string Name { get; set; }

        public string Website { get; set; }

        [Required]
        public string Biography { get; set; }

        [Required]
        public string ImageId { get; set; }

        public Image Image { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<BookSeries> BookSeries { get; set; }
    }
}

namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class BookSeries : BaseModel<int>
    {
        public BookSeries()
        {
            this.Books = new HashSet<Book>();
        }

        [Required]
        public string Name { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

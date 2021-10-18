namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;

    using WonderlandBooks.Data.Common.Models;

    public class BookSeries : BaseModel<int>
    {
        public BookSeries()
        {
            this.Books = new HashSet<Book>();
        }

        public string Name { get; set; }

        public string NumberOfSeries { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

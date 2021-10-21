namespace WonderlandBooks.Services.Models
{
    using System.Collections.Generic;

    public class BookDto
    {
        public BookDto()
        {
            this.BookGenre = new List<string>();
            this.BookCharacters = new List<string>();
        }

        public string BookName { get; set; }

        public string BookAuthorName { get; set; }

        public string BookUrl { get; set; }

        public string BookDiscription { get; set; }

        public int? BookPages { get; set; }

        public int? BookNumberOfSet { get; set; }

        public string BookSeriesName { get; set; }

        public string BookImage { get; set; }

        public string BookEditionLanguage { get; set; }

        public ICollection<string> BookGenre { get; set; }

        public ICollection<string> BookCharacters { get; set; }
    }
}

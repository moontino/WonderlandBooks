namespace WonderlandBooks.Services.Models
{
    using System.Collections.Generic;

    public class AuthorBooksDto
    {
        public AuthorBooksDto()
        {
            this.AuthorGenre = new List<string>();
            this.AuthorBooks = new List<BookDto>();
        }

        public string AuthorName { get; set; }

        public string AuthorWebsite { get; set; }

        public string AuthorBiography { get; set; }

        public string AuthorImage { get; set; }

        public ICollection<string> AuthorGenre { get; set; }

        public ICollection<BookDto> AuthorBooks { get; set; }
    }
}

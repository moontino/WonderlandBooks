namespace WonderlandBooks.Services.Data.ControllerDataService.Models
{
    using System.Collections.Generic;

    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AuthorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Biography { get; set; }

        public string ImageUrl { get; set; }

        public string Genres { get; set; }

        public IList<AuthorBooksDto> Books { get; set; }

        public IList<AuthorSeriesDto> Series { get; set; }
    }
}

namespace WonderlandBooks.Services.Data.ControllerDataService.Models
{
    public class AuthorBooksDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Pages { get; set; }

        public string BookUrl { get; set; }

        public string ImageExtension { get; set; }

        public string EditionLanguageName { get; set; }

        public string Genres { get; set; }

        public string Characters { get; set; }
    }
}

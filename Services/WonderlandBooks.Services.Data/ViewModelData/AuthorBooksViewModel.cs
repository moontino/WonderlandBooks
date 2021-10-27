namespace WonderlandBooks.Services.Data.ViewModelData
{
    using System.Collections.Generic;

    public class AuthorBooksViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Pages { get; set; }

        public string BookUrl { get; set; }

        public string ImageUrl { get; set; }

        public string EditionLanguageName { get; set; }

        public string Genres { get; set; }

        public string Characters { get; set; }
    }
}

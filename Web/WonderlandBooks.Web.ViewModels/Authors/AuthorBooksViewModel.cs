namespace WonderlandBooks.Web.ViewModels.Authors
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

        public IList<string> Genres { get; set; }

        public IList<string> Characters { get; set; }
    }
}

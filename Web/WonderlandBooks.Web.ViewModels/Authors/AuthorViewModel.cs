namespace WonderlandBooks.Web.ViewModels.Authors
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Biography { get; set; }

        public string ImageUrl { get; set; }

        public IList<string> Genres { get; set; }

        public IList<AuthorBooksViewModel> Books { get; set; }
    }
}

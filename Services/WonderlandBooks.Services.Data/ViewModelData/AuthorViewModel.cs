namespace WonderlandBooks.Services.Data.ViewModelData
{
    using System.Collections.Generic;

    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Biography { get; set; }

        public string ImageUrl { get; set; }

        public string Genres { get; set; }

        public IList<AuthorBooksViewModel> Books { get; set; }
    }
}

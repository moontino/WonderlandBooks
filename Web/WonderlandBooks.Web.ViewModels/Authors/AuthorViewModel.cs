namespace WonderlandBooks.Web.ViewModels.Authors
{
    using System.Collections.Generic;

    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AuthorViewModel : IMapFrom<Author>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Biography { get; set; }

        public string ImageUrl { get; set; }

        public string Genres { get; set; }

        public IList<AuthorBooksViewModel> Books { get; set; }

        public IList<AuthorSeriesViewModel> Series { get; set; }
    }
}

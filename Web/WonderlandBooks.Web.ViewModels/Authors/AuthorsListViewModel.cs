namespace WonderlandBooks.Web.ViewModels.Authors
{
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AuthorsListViewModel : IMapFrom<Author>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int BooksCount { get; set; }
    }
}

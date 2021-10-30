namespace WonderlandBooks.Web.ViewModels.Books
{
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AllBooksViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageExtension { get; set; }
    }
}

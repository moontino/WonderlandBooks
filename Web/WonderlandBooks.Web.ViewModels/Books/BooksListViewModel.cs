namespace WonderlandBooks.Web.ViewModels.Books
{
    using System.Linq;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class BooksListViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }
    }
}

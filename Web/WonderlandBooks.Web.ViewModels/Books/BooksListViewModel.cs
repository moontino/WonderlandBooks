namespace WonderlandBooks.Web.ViewModels.Books
{
    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class BooksListViewModel : BasicBookViewModel, IMapFrom<Book>
    {
    }
}

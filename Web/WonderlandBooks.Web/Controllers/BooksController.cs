namespace WonderlandBooks.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BooksController : BaseController
    {
        private readonly IGetBookByIdService getBookService;
        private readonly IMapper mapper;
        private readonly IAllAuthorBooks authorBooks;

        public BooksController(
            IGetBookByIdService getBookService,
            IMapper mapper,
            IAllAuthorBooks authorBooks)
        {
            this.getBookService = getBookService;
            this.mapper = mapper;
            this.authorBooks = authorBooks;
        }

        public IActionResult Book(int id)
        {
            var model = this.mapper.Map<BookViewModel>(this.getBookService.GetBook(id));

            return this.View(model);
        }

        public IActionResult AllBooks(int id)
        {
            AllBooksListViewModel model = new()
            {
                Books = this.authorBooks.GetBooks<AllBooksViewModel>(id),
            };

            return this.View(model);
        }
    }
}

namespace WonderlandBooks.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Services.Data.ModelDataServices;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BooksController : BaseController
    {

        private readonly IMapper mapper;
        private readonly IBooksService booksService;
        private readonly IBookRecommendationsService bookRecommendations;

        public BooksController(
            IMapper mapper,
            IBooksService booksService,
            IBookRecommendationsService bookRecommendations)
        {
            this.mapper = mapper;
            this.booksService = booksService;
            this.bookRecommendations = bookRecommendations;
        }

        public IActionResult Book(int id)
        {
            var model = this.mapper.Map<BookViewModel>(this.booksService.Book<BookViewModel>(id));
            return this.View(model);
        }
    }
}

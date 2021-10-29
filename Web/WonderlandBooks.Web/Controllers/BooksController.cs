namespace WonderlandBooks.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerServiceData;
    using WonderlandBooks.Services.Mapping;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BooksController : BaseController
    {
        private readonly IGetBookByIdService getBookService;
        private readonly IMapper mapper;

        public BooksController(
            IGetBookByIdService getBookService,
            IMapper mapper)
        {
            this.getBookService = getBookService;
            this.mapper = mapper;
        }

        public IActionResult Book(int id)
        {
            var model = this.mapper.Map<BookViewModel>(this.getBookService.GetBook(id));

            return this.View(model);
        }
    }
}

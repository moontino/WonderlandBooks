namespace WonderlandBooks.Web.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Services.Data.InputDataServices;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BooksController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IBooksService booksService;
        private readonly UserManager<ApplicationUser> userManager;

        public BooksController(
            IMapper mapper,
            IBooksService booksService,
            UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.booksService = booksService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Book(int id)
        {
            const int RANDOM_BOOKS_COUNT = 12;

            var model = new RandomListBookViewModel
            {

                Book = this.mapper.Map<BookViewModel>(this.booksService.GetBook<BookViewModel>(id)),
                RandomBooks = this.booksService.GetRandom<BooksListViewModel>(RANDOM_BOOKS_COUNT),
            };

            return this.View(model);
        }

        public async Task<IActionResult> Library()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.mapper.Map<ListOfBooksLibraryViewModel>(this.booksService.GetLibrary<ListOfBooksLibraryViewModel>(user.Id));

            return this.View(model);
        }

        public IActionResult AllBooks(int id = 1)
        {
            const int ItemPerPage = 16;
            var model = new BooksPagingViewModel()
            {
                ItemPerPage = ItemPerPage,
                PageNumber = id,
                Count = this.booksService.GetCount(),
                Books = this.booksService.GetAllBooks<BooksListViewModel>(id, ItemPerPage),
            };

            return this.View(model);
        }

        public IActionResult SearchBook(string search, int id = 1)
        {

            int itemPerPage = this.booksService.GetCountBySearch(search) > 10 ? 10 : this.booksService.GetCountBySearch(search);
            var model = new SearchListBookViewModel
            {
                ItemPerPage = itemPerPage,
                PageNumber = id,
                SearchString = search,
                Count = this.booksService.GetCountBySearch(search),
                Books = this.booksService.GetBooksByName<SearchBooksViewModel>(search, id, itemPerPage),
            };

            return this.View(model);
        }
    }
}

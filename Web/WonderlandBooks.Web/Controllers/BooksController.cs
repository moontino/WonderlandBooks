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
        private readonly ICreateLibraryService libraryService;

        public BooksController(
            IMapper mapper,
            IBooksService booksService,
            UserManager<ApplicationUser> userManager,
            ICreateLibraryService libraryService)
        {
            this.mapper = mapper;
            this.booksService = booksService;
            this.userManager = userManager;
            this.libraryService = libraryService;
        }

        public IActionResult Book(int id)
        {
            const int RANDOM_BOOKS_COUNT = 12;

            var model = new RandomListBookViewModel
            {
                Book = this.mapper.Map<BookViewModel>(this.booksService.GetBook<BookViewModel>(id)),
                RandomBooks = this.booksService.GetRandom<BooksListViewModel>(RANDOM_BOOKS_COUNT),
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveBookAsync(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.libraryService.SaveAsync(user.Id, id);

            return this.Redirect($"Library");
        }

        public async Task<IActionResult> Library()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.mapper.Map<ListOfBooksLibraryViewModel>(this.booksService.GetLibrary(user.Id));

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
            const int ItemPerPage = 10;
            var model = new SearchListBookViewModel
            {
                ItemPerPage = ItemPerPage,
                PageNumber = id,
                Count = this.booksService.GetCountBySearch(search),
                Books = this.booksService.GetBooksByName<SearchBooksViewModel>(search, id, ItemPerPage),
            };

            return this.View(model);
        }
    }
}

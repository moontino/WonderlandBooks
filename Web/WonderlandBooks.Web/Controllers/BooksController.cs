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
    using WonderlandBooks.Services.Data.ModelDataServices;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BooksController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IBooksService booksService;
        private readonly IBookRecommendationsService bookRecommendations;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILibraryService libraryService;

        public BooksController(
            IMapper mapper,
            IBooksService booksService,
            IBookRecommendationsService bookRecommendations,
            UserManager<ApplicationUser> userManager,
            ILibraryService libraryService)
        {
            this.mapper = mapper;
            this.booksService = booksService;
            this.bookRecommendations = bookRecommendations;
            this.userManager = userManager;
            this.libraryService = libraryService;
        }

        public IActionResult Book(int id)
        {
            var model = this.mapper.Map<BookViewModel>(this.booksService.GetBook<BookViewModel>(id));
            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveBookAsync(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.libraryService.SaveAsync(user.Id, id);

            return this.Redirect($"Book/{id}");
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
    }
}

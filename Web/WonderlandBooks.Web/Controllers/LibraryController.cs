namespace WonderlandBooks.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Services.Data.InputDataServices;
    using WonderlandBooks.Web.ViewModels.Libraries;

    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : BaseController
    {
        private readonly ILibraryService libraryService;
        private readonly IModifiedLibraryService createLibraryService;
        private readonly IModifiedLibraryService modifiedLibrary;

        public LibraryController(
            ILibraryService libraryService,
            IModifiedLibraryService createLibraryService,
            IModifiedLibraryService modifiedLibrary)
        {
            this.libraryService = libraryService;
            this.createLibraryService = createLibraryService;
            this.modifiedLibrary = modifiedLibrary;
        }

        [Authorize]
        [HttpPost("type")]
        public async Task<ActionResult<int>> ChangeReadType(LibraryReadTypeViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.modifiedLibrary.ChangeType(userId, model.BookId, model.Value);
            return model.Value;
        }

        [Authorize]
        [HttpPost("delete")]
        public async Task<ActionResult<int>> RemoveBook(LibraryRemoveBookViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.modifiedLibrary.RemoveBook(userId, model.Id);
            return model.Id;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<bool>> AddBook(LibraryAddBookVireModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.createLibraryService.SaveAsync(userId, model.BookId);
            var isThere = this.libraryService.IsBookInUserLibrary(model.BookId, userId);

            this.libraryService.Test(model.BookId, userId);
            return isThere;
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<bool> IsBookInLibrary(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isThere = this.libraryService.IsBookInUserLibrary(id, userId);

            return isThere;
        }
    }
}

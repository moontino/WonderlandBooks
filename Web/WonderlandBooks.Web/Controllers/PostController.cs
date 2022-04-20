namespace WonderlandBooks.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Services.Data.InputDataServices;
    using WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList;
    using WonderlandBooks.Web.ViewModels.Post;

    public class PostController : BaseController
    {
        private readonly IGenreInputModelListItems genreInputModel;
        private readonly IModifiedPostService editPostService;
        private readonly IPostService postService;

        public PostController(
            IGenreInputModelListItems genreInputModel,
            IModifiedPostService editPostService,
            IPostService postService)
        {
            this.genreInputModel = genreInputModel;
            this.editPostService = editPostService;
            this.postService = postService;
        }

        [Authorize]
        public IActionResult ById(int id)
        {
            var model = this.postService.ById<PostViewModel>(id);
            return this.View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewBag.Genres = new SelectList(this.genreInputModel.Options, "Value", "Text");

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewBag.Genres = new SelectList(this.genreInputModel.Options, "Value", "Text");
                return this.View(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.editPostService.CreateAsync(model, userId);

            return this.Redirect("/Genres/GenreList");
        }
    }
}

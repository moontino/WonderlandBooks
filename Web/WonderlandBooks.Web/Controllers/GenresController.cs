namespace WonderlandBooks.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels.Genres;

    public class GenresController : BaseController
    {
        private readonly IGenreSerivice genreSerivice;
        private readonly IPostService postService;

        public GenresController(
            IGenreSerivice genreSerivice,
            IPostService postService)
        {
            this.genreSerivice = genreSerivice;
            this.postService = postService;
        }

        public IActionResult GenreList()
        {
            var model = new GenreListViewModel
            {
                Genres = this.genreSerivice.TopGenres<GenreViewModel>(),
            };
            return this.View(model);
        }

        public IActionResult PostByName(int id, int page = 1)
        {
            int itemPerPage = 10;
            var model = this.genreSerivice.PostByName<GenrePostViewModel>(id);
            model.ItemPerPage = itemPerPage;
            model.PageNumber = page;
            model.Count = this.postService.GetCount(id);
            model.FormPost = this.postService.GetPostByGenre<PostViewModel>(id, page, itemPerPage);
            return this.View(model);
        }
    }
}

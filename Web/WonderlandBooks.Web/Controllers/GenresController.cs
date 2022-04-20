namespace WonderlandBooks.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels.Genres;

    public class GenresController : BaseController
    {
        private readonly IGenreSerivice postSerivice;

        public GenresController(IGenreSerivice postSerivice)
        {
            this.postSerivice = postSerivice;
        }

        public IActionResult GenreList()
        {
            var model = new GenreListViewModel
            {
                Genres = this.postSerivice.TopGenres<GenreViewModel>(),
            };
            return this.View(model);
        }

        public IActionResult PostByName(int id)
        {
            var model = this.postSerivice.PostByName<GenrePostViewModel>(id);
            return this.View(model);
        }
    }
}

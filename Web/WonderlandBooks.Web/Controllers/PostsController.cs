using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WonderlandBooks.Services.Data.ControllerDataService;
using WonderlandBooks.Web.ViewModels.Posts;

namespace WonderlandBooks.Web.Controllers
{
    public class PostsController : BaseController
    {
        private readonly IPostSerivice postSerivice;

        public PostsController(IPostSerivice postSerivice)
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

        public IActionResult Post(int id)
        {
            var model = this.postSerivice.PostById<GenrePostViewModel>(id);
            return this.View(model);
        }
    }
}

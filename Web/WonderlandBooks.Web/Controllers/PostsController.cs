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

        public IActionResult HomePost()
        {
            var model = new HomeGenreListViewModel
            {
                Genres = this.postSerivice.TopGenres<HomeGenreViewModel>(),
            };
            return this.View(model);
        }
    }
}

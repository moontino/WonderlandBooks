namespace WonderlandBooks.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerServiceData;
    using WonderlandBooks.Web.ViewModels.Authors;

    public class AuthorsController : BaseController
    {
        private readonly ITopTenAuthorsByBookCountService authorsCountService;
        private readonly IGetAuthorById getAuthor;

        public AuthorsController(ITopTenAuthorsByBookCountService authorsCountService, IGetAuthorById getAuthor)
        {
            this.authorsCountService = authorsCountService;
            this.getAuthor = getAuthor;
        }

        public IActionResult GetTopTenAuthorsByBooksCount()
        {
            var viewModel = new TopTenAuthorsViewModel
            {
                Authors = this.authorsCountService.GetAuthors<TopTenAuthorsByBooksCount>(),
            };

            return this.View(viewModel);
        }

        public IActionResult GetAuthor(int id)
        {
            AuthorViewModel view = this.getAuthor.Author(id);

            return this.View(view);
        }
    }
}

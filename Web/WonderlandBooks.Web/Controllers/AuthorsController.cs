namespace WonderlandBooks.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels.Authors;

    public class AuthorsController : BaseController
    {
        private readonly ITopTenAuthorsByBookCountService authorsCountService;
        private readonly IGetAuthorByIdService getAuthorService;
        private readonly IMapper mapper;

        public AuthorsController(
            ITopTenAuthorsByBookCountService authorsCountService,
            IGetAuthorByIdService getAuthorService,
            IMapper mapper)
        {
            this.authorsCountService = authorsCountService;
            this.getAuthorService = getAuthorService;
            this.mapper = mapper;
        }

        public IActionResult GetTopTenAuthorsByBooksCount()
        {
            var viewModel = new TopTenAuthorsViewModel
            {
                Authors = this.authorsCountService.GetAuthors<TopTenAuthorsByBooksCount>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Author(int id)
        {
            AuthorViewModel view = this.mapper.Map<AuthorViewModel>(this.getAuthorService.Author(id));

            return this.View(view);
        }
    }
}

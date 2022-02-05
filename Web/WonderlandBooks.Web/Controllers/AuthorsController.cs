namespace WonderlandBooks.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels.Authors;

    public class AuthorsController : BaseController
    {
        private readonly IAuthorsService authorsService;
        private readonly IMapper mapper;

        public AuthorsController(
            IAuthorsService authorsService,
            IMapper mapper)
        {
            this.authorsService = authorsService;
            this.mapper = mapper;
        }

        public IActionResult Author(int id)
        {
            var model = this.mapper.Map<AuthorViewModel>(this.authorsService.Author<AuthorViewModel>(id));
            return this.View(model);
        }

        public IActionResult AllAuthors(int id = 1)
        {
            const int ItemPerPage = 8;
            var model = new AuthorsPagingViewModel()
            {
                ItemPerPage = ItemPerPage,
                PageNumber = id,
                Count = this.authorsService.GetCount(),
                Authors = this.authorsService.GetAllBooks<AuthorsListViewModel>(id, ItemPerPage),
            };

            return this.View(model);
        }
    }
}

namespace WonderlandBooks.Web.Controllers
{
    using System.Diagnostics;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels;
    using WonderlandBooks.Web.ViewModels.Home;
    using WonderlandBooks.Web.ViewModels.WelcomePage;

    public class HomeController : BaseController
    {
        private readonly IAuthorsAndBooksPresentationService presentationService;
        private readonly ICountDataService countData;
        private readonly IMapper mapper;

        public HomeController(
            IAuthorsAndBooksPresentationService presentationService,
            ICountDataService countData,
            IMapper mapper)
        {
            this.presentationService = presentationService;
            this.countData = countData;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = this.mapper.Map<CountViewModel>(this.countData.GetCount());

            return this.View(model);
        }

        public IActionResult Welcome()
        {
            var viewModel = new AuthorsAndBooksPresentationListViewModel
            {
                Authors = this.presentationService.GetAllAuthors<AuthorsPresentationViewModel>(),
                Book = this.presentationService.GetHundredBooks<BookPresentationViewModel>(),
            };

            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

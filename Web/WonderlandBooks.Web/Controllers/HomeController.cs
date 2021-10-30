namespace WonderlandBooks.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels;
    using WonderlandBooks.Web.ViewModels.WelcomePage;

    public class HomeController : BaseController
    {
        private readonly IAuthorsAndBooksPresentationService presentationService;

        public HomeController(IAuthorsAndBooksPresentationService presentationService)
        {
            this.presentationService = presentationService;
        }

        public IActionResult Index()
        {
            return this.View();
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

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
        private readonly IBooksService booksService;
        private readonly ICountDataService countData;
        private readonly IMapper mapper;

        public HomeController(
            IBooksService booksService,
            ICountDataService countData,
            IMapper mapper)
        {
            this.booksService = booksService;
            this.countData = countData;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            const int RANDOM_BOOKS_COUNT = 12;

            var model = new HomeViewModel()
            {
                Count = this.mapper.Map<CountViewModel>(this.countData.GetCount()),
                RandomBooks = this.booksService.GetRandom<HomeBooksViewModel>(RANDOM_BOOKS_COUNT),
            };
            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

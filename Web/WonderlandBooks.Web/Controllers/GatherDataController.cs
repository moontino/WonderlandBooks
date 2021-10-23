namespace WonderlandBooks.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services;

    public class GatherDataController : BaseController
    {
        private readonly IGoodreadsDataService goodreadsData;

        public GatherDataController(IGoodreadsDataService goodreadsData)
        {
            this.goodreadsData = goodreadsData;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Add()
        {
            await this.goodreadsData.ImportDataAsync(10000, 11000);

            return this.View();
        }
    }
}

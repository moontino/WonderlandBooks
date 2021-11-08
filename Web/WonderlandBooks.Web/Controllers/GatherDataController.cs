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
            // 164187-169187
            for (int i = 1; i < 9; i++)
            {
                var start = int.Parse("16" + i + "187");
                var end = int.Parse("16" + (i + 1) + "187");

                await this.goodreadsData.ImportDataAsync(start, end);
            }

            return this.View();
        }
    }
}

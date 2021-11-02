namespace WonderlandBooks.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CreativeWritingController : BaseController
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
namespace WonderlandBooks.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BookController : BaseController
    {
        public IActionResult GetBook(int id)
        {
            return this.View();
        }
    }
}

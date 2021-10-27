namespace WonderlandBooks.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookController : BaseController
    {
        public IActionResult GetBook(int id)
        {

            return this.View();
        }
    }
}

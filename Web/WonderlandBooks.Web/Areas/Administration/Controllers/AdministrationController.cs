namespace WonderlandBooks.Web.Areas.Administration.Controllers
{
    using WonderlandBooks.Common;
    using WonderlandBooks.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

namespace WonderlandBooks.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.InputDataServices;
    using WonderlandBooks.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private readonly IModifiedCommentService commentService;

        public CommentsController(IModifiedCommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.commentService.CreateAsync(model.PostId, userId, model.Content);
            return this.RedirectToAction("ById", "Posts", new { id = model.PostId });
        }
    }
}

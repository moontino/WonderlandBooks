namespace WonderlandBooks.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels.VoteBooks;

    [ApiController]
    [Route("api/[controller]")]
    public class VoteBookController : BaseController
    {
        private readonly IVoteBookService voteService;

        public VoteBookController(IVoteBookService voteService)
        {
            this.voteService = voteService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVoteViewModel>> Post(PostVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.voteService.SetVoteAsync(input.BookId, userId, input.Value);

            var avaregeVotes = this.voteService.GetAvarageVotes(input.BookId);
            return new PostVoteViewModel { AverageVote = avaregeVotes };
        }
    }
}

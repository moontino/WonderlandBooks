namespace WonderlandBooks.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Web.ViewModels.VotePosts;

    [ApiController]
    [Route("api/[controller]")]
    public class VotePostsController : BaseController
    {
        private readonly IVotePostService voteService;

        public VotePostsController(IVotePostService voteService)
        {
            this.voteService = voteService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Post(VotePostInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.voteService.SetVoteAsync(input.PostId, userId, input.IsUpVote);

            var countVotes = this.voteService.GetVotes(input.PostId);
            return countVotes;
        }
    }
}

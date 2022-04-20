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
    public class VoteBooksController : BaseController
    {
        private readonly IVoteBookService voteService;

        public VoteBooksController(IVoteBookService voteService)
        {
            this.voteService = voteService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BookVoteViewModel>> Post(BookVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.voteService.SetVoteAsync(input.BookId, userId, input.Value);

            var avaregeVotes = this.voteService.GetAvarageVotes(input.BookId);
            return new BookVoteViewModel { AverageVote = avaregeVotes };
        }
    }
}

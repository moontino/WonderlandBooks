namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class VotePostService : IVotePostService
    {
        private readonly IRepository<VotePost> repositoryVote;

        public VotePostService(IRepository<VotePost> repositoryVote)
        {
            this.repositoryVote = repositoryVote;
        }

        public int GetVotes(int postId)
        {
            return this.repositoryVote.All()
                    .Where(x => x.Id == postId)
                    .Sum(x => (int)x.Type);
        }

        public async Task SetVoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = this.repositoryVote.All()
                .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (vote == null)
            {
                vote = new VotePost
                {
                    PostId = postId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };
                await this.repositoryVote.AddAsync(vote);
            }
            else
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }

            await this.repositoryVote.SaveChangesAsync();
        }
    }
}

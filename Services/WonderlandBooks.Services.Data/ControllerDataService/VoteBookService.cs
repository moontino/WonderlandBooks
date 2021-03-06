namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class VoteBookService : IVoteBookService
    {
        private readonly IRepository<VoteBook> votesRepository;

        public VoteBookService(IRepository<VoteBook> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAvarageVotes(int bookId)
        {
            return this.votesRepository.All()
                  .Where(x => x.BookId == bookId)
                  .Average(x => x.Value);
        }

        public async Task SetVoteAsync(int bookId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                  .FirstOrDefault(x => x.BookId == bookId && x.UserId == userId);

            if (vote == null)
            {
                vote = new VoteBook
                {
                    BookId = bookId,
                    UserId = userId,
                    Value = value,
                };
                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}

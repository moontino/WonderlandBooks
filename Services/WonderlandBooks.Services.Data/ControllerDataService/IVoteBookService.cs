namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Threading.Tasks;

    public interface IVoteBookService
    {
        Task SetVoteAsync(int bookId, string userId, byte value);

        double GetAvarageVotes(int bookId);
    }
}

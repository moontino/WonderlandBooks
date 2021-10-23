namespace WonderlandBooks.Services
{
    using System.Threading.Tasks;

    public interface IGoodreadsDataService
    {
        Task ImportDataAsync(int fromId, int toId);
    }
}

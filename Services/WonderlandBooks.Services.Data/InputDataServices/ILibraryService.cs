using System.Threading.Tasks;

namespace WonderlandBooks.Services.Data.InputDataServices
{
    public interface ILibraryService
    {
        Task SaveAsync(string userId, int bookId);
    }
}

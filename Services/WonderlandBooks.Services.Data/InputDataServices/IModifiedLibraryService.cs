using System.Threading.Tasks;

namespace WonderlandBooks.Services.Data.InputDataServices
{
    public interface IModifiedLibraryService
    {
        Task SaveAsync(string userId, int bookId);

        Task ChangeType(string userId, int bookId, int value);

        Task RemoveBook(string userId,int bookId);
    }
}

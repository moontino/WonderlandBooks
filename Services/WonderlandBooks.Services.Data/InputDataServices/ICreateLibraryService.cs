using System.Threading.Tasks;

namespace WonderlandBooks.Services.Data.InputDataServices
{
    public interface ICreateLibraryService
    {
        Task SaveAsync(string userId, int bookId);
    }
}

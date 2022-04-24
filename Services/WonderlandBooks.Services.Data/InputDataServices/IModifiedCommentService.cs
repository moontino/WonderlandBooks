namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    public interface IModifiedCommentService
    {
        Task CreateAsync(int postId, string userId, string content, int? parentId = null);
    }
}

namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Web.ViewModels.Posts;

    public interface IModifiedPostService
    {
        Task CreateAsync(PostCreateInputModel input, string userId);
    }
}

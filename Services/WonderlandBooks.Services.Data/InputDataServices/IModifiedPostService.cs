namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Web.ViewModels.Post;

    public interface IModifiedPostService
    {
        Task CreateAsync(PostCreateInputModel input, string userId);
    }
}

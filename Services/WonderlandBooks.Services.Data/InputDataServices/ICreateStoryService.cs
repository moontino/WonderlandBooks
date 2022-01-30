namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public interface ICreateStoryService
    {
        Task CreateAsync(CreateStoryInputModel input, string imagePath);
    }
}

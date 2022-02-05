namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public interface IStoryService
    {
        Task CreateAsync(CreateStoryInputModel input, string imagePath);

        Task UpdateAsync(UpdateStoryViewModel input, string imagelocal, string imagePath);

        Task DeleteAsync(int id);
    }
}

namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public interface IModifiedChapterService
    {
        Task CreateAsync(CreateChapterInputModel input);

        Task UpdateAsync(UpdateChapterViewModel input);
    }
}

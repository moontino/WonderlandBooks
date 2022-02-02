namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public interface IChapterService
    {
        Task CreateAsync(CreateChapterInputModel input);
    }
}

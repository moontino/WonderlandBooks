namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using WonderlandBooks.Services.Data.ControllerDataService.Models;

    public interface IGetAuthorByIdService
    {
        AuthorDto Author(int id);
    }
}

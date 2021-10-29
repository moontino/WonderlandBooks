namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using WonderlandBooks.Services.Data.ControllerServiceData.Models;

    public interface IGetAuthorByIdService
    {
        AuthorDto Author(int id);
    }
}

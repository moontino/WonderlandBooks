namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using WonderlandBooks.Services.Data.ViewModelData;

    public interface IGetAuthorById
    {
        AuthorViewModel Author(int id);
    }
}

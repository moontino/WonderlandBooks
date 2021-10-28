namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using WonderlandBooks.Web.ViewModels.Authors;

    public interface IGetAuthorById
    {
        AuthorViewModel Author(int id);
    }
}

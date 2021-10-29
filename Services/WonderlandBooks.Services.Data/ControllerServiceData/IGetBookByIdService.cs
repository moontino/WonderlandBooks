namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using WonderlandBooks.Services.Data.ControllerServiceData.Models;

    public interface IGetBookByIdService
    {
        BookDto GetBook(int id);
    }
}

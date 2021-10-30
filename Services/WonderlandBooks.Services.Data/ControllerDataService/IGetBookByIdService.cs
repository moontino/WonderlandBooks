namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using WonderlandBooks.Services.Data.ControllerDataService.Models;

    public interface IGetBookByIdService
    {
        BookDto GetBook(int id);
    }
}

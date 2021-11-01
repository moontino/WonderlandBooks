namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IAllAuthorBooksService
    {
        IList<T> GetBooks<T>(int id);
    }
}

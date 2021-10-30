namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IAllAuthorBooks
    {
        IList<T> GetBooks<T>(int id);
    }
}

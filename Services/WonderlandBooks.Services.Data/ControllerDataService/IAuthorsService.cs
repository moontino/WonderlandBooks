namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IAuthorsService
    {
        IList<T> GetTenAuthors<T>();

        T Author<T>(int id);

        IEnumerable<T> SingleBooks<T>(int id);

        int GetCount();

        IEnumerable<T> GetAllBooks<T>(int page, int itemsPerPage = 8);
    }
}

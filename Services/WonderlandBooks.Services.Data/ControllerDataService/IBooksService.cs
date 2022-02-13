namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    using WonderlandBooks.Web.ViewModels.Books;

    public interface IBooksService
    {
        IList<T> GetTenBooks<T>();

        T GetBook<T>(int id);

        ListOfBooksLibraryViewModel GetLibrary(string id);

        IEnumerable<T> GetAllBooks<T>(int page, int itemsPerPage = 16);

        int GetCount();

        int GetCountBySearch(string name);

        IEnumerable<T> GetRandom<T>(int count);

        IEnumerable<T> GetBooksByName<T>(string name, int page, int itemsPerPage = 10);
    }
}

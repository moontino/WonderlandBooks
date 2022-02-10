﻿namespace WonderlandBooks.Services.Data.ControllerDataService
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

        IEnumerable<T> GetRandom<T>(int count);
    }
}

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IAuthorsAndBooksPresentationService
    {
        IList<T> GetAllAuthors<T>();

        IList<T> GetHundredBooks<T>();
    }
}

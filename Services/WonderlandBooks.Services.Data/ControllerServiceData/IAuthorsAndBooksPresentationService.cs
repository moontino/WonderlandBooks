namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using System.Collections.Generic;

    public interface IAuthorsAndBooksPresentationService
    {
        IList<T> GetAllAuthors<T>();

        IList<T> GetHundredBooks<T>();
    }
}

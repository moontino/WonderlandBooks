namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface ITopTenAuthorsByBookCountService
    {
        IEnumerable<T> GetAuthors<T>();
    }
}

namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using System.Collections.Generic;

    public interface ITopTenAuthorsByBookCountService
    {
        IEnumerable<T> GetAuthors<T>();
    }
}

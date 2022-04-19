namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IPostSerivice
    {
        IEnumerable<T> TopGenres<T>();
    }
}

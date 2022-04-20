namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IGenreSerivice
    {
        IEnumerable<T> TopGenres<T>();

        T PostByName<T>(int id);
    }
}

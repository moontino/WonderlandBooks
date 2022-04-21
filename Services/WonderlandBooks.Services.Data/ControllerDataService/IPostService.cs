namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IPostService
    {
        T ById<T>(int id);

        IEnumerable<T> GetPostByGenre<T>(int id, int page, int itemsPerPage = 10);

        int GetCount(int id);
    }
}

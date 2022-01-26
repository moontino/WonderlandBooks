using System.Collections.Generic;

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public interface IBooksService
    {
        IList<T> GetTenBooks<T>();

        T Book<T>(int id);
    }
}

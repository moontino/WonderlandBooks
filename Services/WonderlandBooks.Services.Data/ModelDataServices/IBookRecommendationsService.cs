namespace WonderlandBooks.Services.Data.ModelDataServices
{
    using System.Collections.Generic;

    public interface IBookRecommendationsService
    {
        IList<int> RandomArrayId(int number);
    }
}

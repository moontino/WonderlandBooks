namespace WonderlandBooks.Services.Data.ModelDataServices
{
    using System.Collections.Generic;

    public interface IBookRecommendationsService
    {
        T Recommendation<T>(int id, int count);

        T RandomRecommendation<T>(int id, int count);
    }
}

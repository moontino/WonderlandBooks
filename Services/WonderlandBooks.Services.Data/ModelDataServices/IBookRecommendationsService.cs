namespace WonderlandBooks.Services.Data.ModelDataServices
{
    using System.Collections.Generic;

    using WonderlandBooks.Services.Data.ControllerDataService.Models;

    public interface IBookRecommendationsService
    {
        IList<BookRecommendationsDto> Recommendation(int id, int count);

        IList<BookRecommendationsDto> RandomRecommendation(int id, int count);
    }
}

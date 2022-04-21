namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IStoriesService
    {
        T UserWritring<T>(string id);

        T CurrentStory<T>(int storyId);

        IEnumerable<T> AllStories<T>(int page, int itemsPerPage = 8);

        IEnumerable<T> StoriesByUser<T>(string userId, int page, int itemsPerPage = 8);

        int GetCountByUser(string userId);

        int GetAllCount();
    }
}

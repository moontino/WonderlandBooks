namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    public interface IStoriesService
    {
        T StoriesByUser<T>(string id);

        T CurrentStory<T>(int storyId);

        IEnumerable<T> AllStories<T>(int page, int itemsPerPage = 8);

        int GetCount();
    }
}

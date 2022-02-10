namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public interface IChapterService
    {
        IEnumerable<T> AllStoryChapters<T>(int storyId);

        T CurrentChapter<T>(int chapterId);
    }
}

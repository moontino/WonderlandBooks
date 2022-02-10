using System.Collections.Generic;
using System.Linq;
using WonderlandBooks.Data.Common.Repositories;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;
using WonderlandBooks.Web.ViewModels.CreativeWriting;

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public class ChapterService : IChapterService
    {
        private readonly IDeletableEntityRepository<Story> stories;
        private readonly IDeletableEntityRepository<Chapter> chapters;

        public ChapterService(
            IDeletableEntityRepository<Story> stories,
            IDeletableEntityRepository<Chapter> chapters)
        {
            this.stories = stories;
            this.chapters = chapters;
        }

        public IEnumerable<T> AllStoryChapters<T>(int storyId)
        {
            return this.stories.AllAsNoTracking()
                 .Where(x => x.Id == storyId)
                 .To<T>()
                 .ToList();
        }

        public T CurrentChapter<T>(int chapterId)
        {
            return this.chapters.All()
                .Where(x => x.Id == chapterId)
                .To<T>()
                .FirstOrDefault();
        }
    }
}

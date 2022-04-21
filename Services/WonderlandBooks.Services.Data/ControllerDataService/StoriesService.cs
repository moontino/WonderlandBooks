namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class StoriesService : IStoriesService
    {
        private readonly IDeletableEntityRepository<Story> stories;
        private readonly IRepository<CreativeWriting> writing;

        public StoriesService(IDeletableEntityRepository<Story> stories, IRepository<CreativeWriting> writing)
        {
            this.stories = stories;
            this.writing = writing;
        }

        public T UserWritring<T>(string id)
        {
            return this.writing.All()
                   .Where(x => x.UserId == id)
                   .To<T>()
                   .FirstOrDefault();
        }

        public IEnumerable<T> StoriesByUser<T>(string userId, int page, int itemsPerPage = 8)
        {
            return this.stories.All()
                   .Where(x => x.CreativeWriting.UserId ==userId)
                   .Skip((page - 1) * itemsPerPage)
                   .Take(itemsPerPage)
                   .To<T>()
                   .ToList();
        }

        public T CurrentStory<T>(int storyId)
        {
            return this.stories.All()
                .Where(x => x.Id == storyId)
                .To<T>()
                .FirstOrDefault();
        }

        public IEnumerable<T> AllStories<T>(int page, int itemsPerPage = 8)
        {
            return this.stories.All()
                .OrderByDescending(x => x.Chapters.Count())
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .To<T>()
                 .ToList();
        }

        public int GetCountByUser(string userId)
        {
            return this.stories.AllAsNoTracking()
                 .Where(x => x.CreativeWriting.UserId == userId)
                 .Count();
        }

        public int GetAllCount()
        {
            return this.stories.AllAsNoTracking().Count();
        }
    }
}

using System.Linq;

using WonderlandBooks.Data.Common.Repositories;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;
using WonderlandBooks.Web.ViewModels.CreativeWriting;

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public class StoriesService : IStoriesService
    {
        private readonly IDeletableEntityRepository<Story> stories;
        private readonly IRepository<CreativeWriting> writing;

        public StoriesService(IDeletableEntityRepository<Story> stories, IRepository<CreativeWriting> writing)
        {
            this.stories = stories;
            this.writing = writing;
        }

        public CollectionOfStories All(string id)
        {
            return this.writing.AllAsNoTracking()
                   .Where(x => x.UserId == id)
                   .Select(x => new CollectionOfStories
                   {
                       UserId = x.UserId,
                       Stories = x.Stories.Select(s => new StoriesViewModel
                       {
                           Id = s.Id,
                           Title = s.Title,
                           Description = s.Description,
                           Image = s.Image.Url ?? "/images/stories/" + s.Image.Id + s.Image.Extension,
                       }).ToList(),
                   }).FirstOrDefault();
        }

        public T CurrentStory<T>(int storyId)
        {
            return this.stories.All()
                .Where(x => x.Id == storyId)
                .To<T>()
                .FirstOrDefault();
        }
    }
}

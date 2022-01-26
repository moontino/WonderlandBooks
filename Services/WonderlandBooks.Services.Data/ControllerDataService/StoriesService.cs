using System.Linq;

using WonderlandBooks.Data.Common.Repositories;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public class StoriesService : IStoriesService
    {
        private readonly IRepository<CreativeWriting> repositoryWriting;

        public StoriesService(IRepository<CreativeWriting> repositoryWriting)
        {
            this.repositoryWriting = repositoryWriting;
        }

        public T All<T>(string id)
        {
            return this.repositoryWriting.AllAsNoTracking()
                   .Where(x => x.UserId == id)
                   .To<T>()
                   .FirstOrDefault();
        }
    }
}

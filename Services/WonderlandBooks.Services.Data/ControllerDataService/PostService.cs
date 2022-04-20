namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public T ById<T>(int id)
        {
            return this.postRepository.All()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefault();
        }
    }
}

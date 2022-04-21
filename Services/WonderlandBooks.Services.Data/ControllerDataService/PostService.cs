namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;
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

        public IEnumerable<T> GetPostByGenre<T>(int id, int page, int itemsPerPage = 10)
        {
            return this.postRepository.AllAsNoTracking()
                   .OrderByDescending(x => x.CreatedOn)
                   .Where(x => x.GenreId == id)
                   .Skip((page - 1) * itemsPerPage)
                   .Take(itemsPerPage)
                   .To<T>()
                   .ToList();
        }

        public int GetCount(int id)
        {
            return this.postRepository.All()
                .Where(x => x.GenreId == id)
                .Count();
        }
    }
}

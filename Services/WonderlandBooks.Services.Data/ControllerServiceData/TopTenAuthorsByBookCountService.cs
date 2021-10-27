namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class TopTenAuthorsByBookCountService : ITopTenAuthorsByBookCountService
    {
        private readonly IRepository<Author> authorRepository;

        public TopTenAuthorsByBookCountService(
            IRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public IEnumerable<T> GetAuthors<T>()
        {
            return this.authorRepository.All()
                .OrderByDescending(x => x.Books.Count())
                .Take(10).To<T>();
        }
    }
}

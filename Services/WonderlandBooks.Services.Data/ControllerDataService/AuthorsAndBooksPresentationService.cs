namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AuthorsAndBooksPresentationService : IAuthorsAndBooksPresentationService
    {
        private readonly IRepository<Author> repositoryAuthors;
        private readonly IRepository<Book> repositoryBooks;

        public AuthorsAndBooksPresentationService(
            IRepository<Author> repositoryAuthors,
            IRepository<Book> repositoryBooks)
        {
            this.repositoryAuthors = repositoryAuthors;
            this.repositoryBooks = repositoryBooks;
        }

        public IList<T> GetAllAuthors<T>()
        {
            return this.repositoryAuthors.All()
                       .Take(6)
                       .To<T>()
                       .ToList();
        }

        public IList<T> GetHundredBooks<T>()
        {
            return this.repositoryBooks.All()
                       .Take(10)
                       .To<T>()
                       .ToList();
        }
    }
}

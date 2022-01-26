namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerDataService.Models;
    using WonderlandBooks.Services.Mapping;
    using WonderlandBooks.Web.ViewModels.Authors;

    public class AuthorsService : IAuthorsService
    {
        private readonly IRepository<Author> repositoryAuthors;
        private readonly IRepository<Book> repositoryBooks;

        public AuthorsService(
            IRepository<Author> repositoryAuthors,
            IRepository<Book> repositoryBooks)
        {
            this.repositoryAuthors = repositoryAuthors;
            this.repositoryBooks = repositoryBooks;
        }

        public IEnumerable<T> SingleBooks<T>(int id)
        {
            var books = this.repositoryBooks.AllAsNoTracking()
                .Where(x => x.Authors.Any(x => x.Id == id))
                .To<T>()
                .ToList();
            return books;
        }

        public T Author<T>(int id)
        {
            return this.repositoryAuthors.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public IList<T> GetTenAuthors<T>()
        {
            return this.repositoryAuthors.AllAsNoTracking()
                       .Take(12)
                       .To<T>()
                       .ToList();
        }
    }
}

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AllAuthorBooksService : IAllAuthorBooksService
    {
        private readonly IRepository<Book> repositoryBooks;

        public AllAuthorBooksService(IRepository<Book> repositoryBooks)
        {
            this.repositoryBooks = repositoryBooks;
        }

        public IList<T> GetBooks<T>(int id)
        {
            return this.repositoryBooks.AllAsNoTracking()
                .Where(x => x.Authors.Any(b => b.Id == id))
                .To<T>()
                .ToList();
        }
    }
}

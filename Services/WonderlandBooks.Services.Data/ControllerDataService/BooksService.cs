namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class BooksService : IBooksService
    {
        private readonly IRepository<Book> repositoryBooks;

        public BooksService(
            IRepository<Book> repositoryBooks)
        {
            this.repositoryBooks = repositoryBooks;
        }

        public T Book<T>(int id)
        {
            var model = this.repositoryBooks.AllAsNoTracking()
               .Where(x => x.Id == id)
               .To<T>()
               .FirstOrDefault();

            return model;
        }

        public IList<T> GetTenBooks<T>()
        {
            return this.repositoryBooks.All()
                          .Take(10)
                          .To<T>()
                          .ToList();
        }
    }
}

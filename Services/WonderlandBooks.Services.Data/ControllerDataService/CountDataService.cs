namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerDataService.Models;

    public class CountDataService : ICountDataService
    {
        private readonly IRepository<Author> repositoryAuthors;
        private readonly IRepository<Book> repositoryBooks;
        private readonly IRepository<Genre> repositoryGenres;
        private readonly IRepository<CreativeWriting> repositoryWriters;

        public CountDataService(
            IRepository<Author> repositoryAuthors,
            IRepository<Book> repositoryBooks,
            IRepository<Genre> repositoryGenres,
            IRepository<CreativeWriting> repositoryWriters)
        {
            this.repositoryAuthors = repositoryAuthors;
            this.repositoryBooks = repositoryBooks;
            this.repositoryGenres = repositoryGenres;
            this.repositoryWriters = repositoryWriters;
        }

        public CountDto GetCount()
        {
            return new CountDto
            {
                CountAuthors = this.repositoryAuthors.AllAsNoTracking().Count(),
                CountBooks = this.repositoryBooks.AllAsNoTracking().Count(),
                CountGenres = this.repositoryGenres.AllAsNoTracking().Count(),
                CountWriting = this.repositoryWriters.AllAsNoTracking().Count(),
            };
        }
    }
}

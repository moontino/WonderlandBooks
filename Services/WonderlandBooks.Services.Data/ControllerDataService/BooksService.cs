namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BooksService : IBooksService
    {
        private readonly IRepository<Book> repositoryBooks;
        private readonly IDeletableEntityRepository<ApplicationUser> users;

        public BooksService(
            IRepository<Book> repositoryBooks,
            IDeletableEntityRepository<ApplicationUser> users)
        {
            this.repositoryBooks = repositoryBooks;
            this.users = users;
        }

        public IEnumerable<T> GetAllBooks<T>(int page, int itemsPerPage = 16)
        {
            return this.repositoryBooks.AllAsNoTracking()
                 .OrderByDescending(x => x.Genres.Count())
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .To<T>()
                 .ToList();
        }

        public T GetBook<T>(int id)
        {
            var model = this.repositoryBooks.AllAsNoTracking()
               .Where(x => x.Id == id)
               .To<T>()
               .FirstOrDefault();

            return model;
        }

        public int GetCount()
        {
            return this.repositoryBooks.All().Count();
        }

        public ListOfBooksLibraryViewModel GetLibrary(string id)
        {
            return this.users.All()
                .Where(x => x.Id == id)
                .Select(x => new ListOfBooksLibraryViewModel
                {
                    Id = x.Id,
                    Shelves = x.Shelves.OrderByDescending(o => o.CreatedOn)
                                       .Select(s => new LibraryBooksViewModel
                                       {
                                           BookId = s.BookId,
                                           BookName = s.Book.Name,
                                           BookImageUrl = s.Book.Image.Url,
                                       }).ToList(),
                }).FirstOrDefault();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.repositoryBooks.All()
                 .OrderBy(x => Guid.NewGuid())
                 .Take(count)
                 .To<T>()
                 .ToList();
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

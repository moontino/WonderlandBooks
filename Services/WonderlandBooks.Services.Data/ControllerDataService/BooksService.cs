namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ModelDataServices;
    using WonderlandBooks.Services.Mapping;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BooksService : IBooksService
    {
        private readonly IRepository<Book> repositoryBooks;
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly IBookRecommendationsService recommendationsService;

        public BooksService(
            IRepository<Book> repositoryBooks,
            IDeletableEntityRepository<ApplicationUser> users,
            IBookRecommendationsService recommendationsService)
        {
            this.repositoryBooks = repositoryBooks;
            this.users = users;
            this.recommendationsService = recommendationsService;
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

        public IEnumerable<T> GetBooksByName<T>(string name, int page, int itemsPerPage = 10)
        {
            return this.repositoryBooks.AllAsNoTracking()
                   .Where(x => x.Name.Contains(name))
                   .OrderBy(x => x.Name)
                   .Skip((page - 1) * itemsPerPage)
                   .Take(itemsPerPage)
                   .To<T>()
                   .ToList();
        }

        public int GetCountBySearch(string name)
        {
            return this.repositoryBooks.AllAsNoTracking()
                .Where(x => x.Name.Contains(name))
                .Count();
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
            var temp = this.recommendationsService.RandomArrayId(12);
            var model = this.repositoryBooks.All()
                 .Where(x => temp.Contains(x.Id))
                 .Take(count)
                 .To<T>()
                 .ToList();
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

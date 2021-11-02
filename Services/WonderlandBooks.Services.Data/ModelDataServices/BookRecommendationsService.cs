namespace WonderlandBooks.Services.Data.ModelDataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerDataService.Models;
    using WonderlandBooks.Services.Data.ModelDataServices;

    // This class is simple recommendation service -> ML.Net need to Replacement it
    public class BookRecommendationsService : IBookRecommendationsService
    {
        private readonly IRepository<Book> repositoryBook;

        public BookRecommendationsService(IRepository<Book> repositoryBook)
        {
            this.repositoryBook = repositoryBook;
        }

        public IList<BookRecommendationsDto> Recommendation(int id, int count)
        {
            var genres = this.repositoryBook.AllAsNoTracking()
               .Where(x => x.Id == id).
               SelectMany(x => x.Genres.Select(g => g.Name))
               .ToList();

            var authors = this.repositoryBook.AllAsNoTracking()
                .Where(x => x.Id == id)
                .SelectMany(x => x.Authors.Select(a => a.Id)).ToList();

            var recommendations = this.repositoryBook.AllAsNoTracking()
                           .OrderByDescending(x => x.Id)
                           .Where(x => x.Genres.Any(x => genres.Contains(x.Name)))
                           .Select(x => new BookRecommendationsDto
                           {
                               Id = x.Id,
                               Name = x.Name,
                               ImageUrl = x.Image.Extension,
                               Authors = x.Authors.Select(a => new BookRecommendationsAuthorsDto
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                               }).ToList(),
                           }).Take(count).ToList();

            if (recommendations.Count == 0)
            {
                return this.RandomRecommendation(id, count);
            }

            return recommendations;
        }

        public IList<BookRecommendationsDto> RandomRecommendation(int id, int count)
        {
            var countBooks = this.repositoryBook.AllAsNoTracking()
                .Where(x => x.Id != id).Count();
            var currentBooksId = this.RandomId(countBooks, id);

            var recommendation = this.repositoryBook.AllAsNoTracking()
                .Where(x => currentBooksId.Contains(x.Id))
                .Select(x => new BookRecommendationsDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.Image.Extension,
                    Authors = x.Authors.Select(a => new BookRecommendationsAuthorsDto
                    {
                        Id = a.Id,
                        Name = a.Name,
                    }).ToList(),
                }).ToList();

            return recommendation;
        }

        private ICollection<int> RandomId(int number, int bookId)
        {
            var random = new Random();

            ICollection<int> ids = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                var id = random.Next(number);
                if (ids.Contains(id) || id == bookId)
                {
                    i--;
                    continue;
                }

                ids.Add(id);
            }

            return ids;
        }
    }
}

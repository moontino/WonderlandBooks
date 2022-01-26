namespace WonderlandBooks.Services.Data.ModelDataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    // This class is simple recommendation service -> ML.Net need to Replacement it
    public class BookRecommendationsService : IBookRecommendationsService
    {
        private readonly IRepository<Book> repositoryBook;

        public BookRecommendationsService(IRepository<Book> repositoryBook)
        {
            this.repositoryBook = repositoryBook;
        }

        public T Recommendation<T>(int id, int count)
        {
            var genres = this.repositoryBook.AllAsNoTracking()
               .Where(x => x.Id == id).
               SelectMany(x => x.Genres.Select(g => g.Name))
               .ToList();

            var recommendations = this.repositoryBook.AllAsNoTracking()
                 .Where(x => x.Genres.Any(x => genres.Contains(x.Name)))
                 .OrderByDescending(x => x.Id)
                 .To<T>()
                 .ToList();

            if (recommendations.Count < count)
            {
                return this.RandomRecommendation<T>(id, count);
            }

            return recommendations.Skip(count).FirstOrDefault();
        }

        public T RandomRecommendation<T>(int id, int count)
        {
            var countBooks = this.repositoryBook.AllAsNoTracking()
                .Where(x => x.Id != id).Count();
            var currentBooksId = this.RandomId(countBooks, id);

            var recommendation = this.repositoryBook.AllAsNoTracking()
                .To<T>()
                .FirstOrDefault();

            return recommendation;
        }

        private int RandomId(int number, int bookId)
        {
            var random = new Random();
            var id = random.Next(1, number);
            if (id == bookId)
            {
                id = random.Next(1, number);
            }

            return id;
        }
    }
}

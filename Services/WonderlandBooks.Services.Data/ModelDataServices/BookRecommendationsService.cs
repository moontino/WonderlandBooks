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

        public IList<int> RandomArrayId(int number)
        {
            var booksCount = this.repositoryBook.All().Count();
            var random = new Random();
            var arr = new List<int>();

            for (int i = 0; i < number; i++)
            {
                var id = random.Next(1, booksCount);
                if (arr.Contains(id))
                {
                    i--;
                }

                arr.Add(id);
            }

            return arr;
        }
    }
}

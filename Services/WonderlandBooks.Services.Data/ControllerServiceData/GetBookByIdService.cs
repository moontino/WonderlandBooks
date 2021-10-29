namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerServiceData.Models;

    public class GetBookByIdService : IGetBookByIdService
    {
        private readonly IRepository<Book> repositoryBook;

        public GetBookByIdService(
            IRepository<Book> repositoryBook)
        {
            this.repositoryBook = repositoryBook;
        }

        public BookDto GetBook(int id)
        {
            var model = this.repositoryBook.AllAsNoTracking()
                        .Select(x => new BookDto
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            NumberOfSet = x.NumberOfSet,
                            SeriesName = x.BookSeries.Name,
                            SeriesId = x.BookSeries.Id,
                            Pages = x.Pages,
                            BookUrl = x.BookUrl,
                            ImageUrl = x.Image.Extension,
                            EditionLanguage = x.EditionLanguage.Name,
                            Genres = string.Join("/", x.Genres.Select(x => x.Name)),
                            Characters = string.Join("/", x.Characters.Select(x => x.Name)),
                            Author = x.Authors.Select(x => new BookAuthorDto
                            {
                                AuthorId = x.Id,
                                AuthorName = x.Name,
                            }).ToList(),
                        }).First(x => x.Id == id);

            string[] genres = this.repositoryBook.AllAsNoTracking()
                .Where(x => x.Id == id)
                .SelectMany(x => x.Genres.Select(x => x.Name)).ToArray();

            var bookRecommendations = this.repositoryBook.AllAsNoTracking()
               .Where(x => x.Genres.Any(x => genres.Contains(x.Name)))
               .Select(x => new BookRecommendationsDto
               {
                   Id = x.Id,
                   Name = x.Name,
                   Genres = string.Join("/", x.Genres.Select(x => x.Name)),//authors name 
                   ImageUrl = x.Image.Extension,
               }).Take(5).ToList();

            // var count = this.TakeFiveBooks(bookRecommendations.Count());
            model.BookRecommendationsByGenre = bookRecommendations;

            return model;
        }

        private int TakeFiveBooks(int count) => count < 5 ? count : 5;
    }
}

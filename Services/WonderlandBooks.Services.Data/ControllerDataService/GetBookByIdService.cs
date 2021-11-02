namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerDataService.Models;
    using WonderlandBooks.Services.Data.ModelDataServices;

    public class GetBookByIdService : IGetBookByIdService
    {
        private const int CountOfRecommendedBooks = 5;

        private readonly IRepository<Book> repositoryBook;
        private readonly IRepository<BookSeries> repositorySeries;
        private readonly IBookRecommendationsService recommendationsService;

        public GetBookByIdService(
            IRepository<Book> repositoryBook,
            IRepository<BookSeries> repositorySeries,
            IBookRecommendationsService recommendationsService)
        {
            this.repositoryBook = repositoryBook;
            this.repositorySeries = repositorySeries;
            this.recommendationsService = recommendationsService;
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
                            ImageUrl = x.Image.Url,
                            EditionLanguage = x.EditionLanguage.Name,
                            Genres = string.Join("/", x.Genres.Select(x => x.Name)),
                            Characters = string.Join("/", x.Characters.Select(x => x.Name)),
                            Author = x.Authors.Select(x => new BookAuthorDto
                            {
                                Id = x.Id,
                                AuthorName = x.Name,
                            }).ToList(),
                        }).First(x => x.Id == id);

            var recommendations = this.recommendationsService.Recommendation(id, CountOfRecommendedBooks);
            model.Recommendations = recommendations;

            if (model.SeriesId != null)
            {
                model.Series = this.repositorySeries.AllAsNoTracking()
                    .Where(x => x.Name == model.SeriesName)
                    .Select(x => new BookSeriesDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        BooksSeries = x.Books
                        .Select(b => new BookSeriesBooksDto
                        {
                            Id = b.Id,
                            Name = b.Name,
                            ImageUrl = b.Image.Url,
                        }).ToList(),
                    }).ToList();
            }

            return model;
        }
    }
}

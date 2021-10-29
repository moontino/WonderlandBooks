namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerServiceData.Models;

    public class GetAuthorByIdService : IGetAuthorByIdService
    {
        private readonly IRepository<Author> repositoryAuthor;
        private readonly IRepository<BookSeries> repositorySeries;

        public GetAuthorByIdService(
            IRepository<Author> repositoryAuthor,
            IRepository<BookSeries> repositorySeries)
        {
            this.repositoryAuthor = repositoryAuthor;
            this.repositorySeries = repositorySeries;
        }

        public AuthorDto Author(int id)
        {
            var author = this.repositoryAuthor.AllAsNoTracking()
                  .Select(author => new AuthorDto
                  {
                      Id = author.Id,
                      Name = author.Name,
                      Biography = author.Biography,
                      Website = author.Website,
                      ImageUrl = author.Image.Url,
                      Genres = string.Join("/", author.Genres.Select(x => x.Name)),
                      Books = author.Books.Where(x => x.NumberOfSet == null).Select(book => new AuthorBooksDto
                      {
                          Id = book.Id,
                          Name = book.Name,
                          ImageExtension = book.Image.Extension,
                          Description = string.IsNullOrWhiteSpace(book.Description) ? ";)" : book.Description.Substring(0, 150),
                          EditionLanguageName = book.EditionLanguage.Name,
                          Pages = book.Pages,
                          BookUrl = book.BookUrl,
                          Genres = string.Join("/", book.Genres.Select(x => x.Name)),
                          Characters = string.Join("/", book.Characters.Select(x => x.Name)),
                      }).ToList(),
                  }).First(x => x.Id == id);

            var series = this.repositorySeries.AllAsNoTracking()
                .Where(x => x.AuthorId == id)
                .Select(x => new AuthorSeriesDto
                {
                    SeriesName = x.Name,
                    Books = x.Books
                    .Select(s => new AuthorSeriesBooksDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        ImageExtension = s.Image.Extension,
                        NumberOfSet = s.NumberOfSet,
                    }).ToList(),
                })
                .OrderBy(x => x.SeriesName)
                .ToList();
            author.Series = series;

            return author;
        }
    }
}

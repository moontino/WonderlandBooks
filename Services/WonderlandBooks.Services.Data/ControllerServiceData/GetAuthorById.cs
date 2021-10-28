namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Web.ViewModels.Authors;

    public class GetAuthorById : IGetAuthorById
    {
        private readonly IRepository<Author> repositoryAuthor;
        private readonly IRepository<BookSeries> repositorySeries;

        public GetAuthorById(IRepository<Author> repositoryAuthor, IRepository<BookSeries> repositorySeries)
        {
            this.repositoryAuthor = repositoryAuthor;
            this.repositorySeries = repositorySeries;
        }

        public AuthorViewModel Author(int id)
        {
            var author = this.repositoryAuthor.AllAsNoTracking()
                  .Select(author => new AuthorViewModel
                  {
                      Id = author.Id,
                      Name = author.Name,
                      Biography = author.Biography,
                      Website = author.Website,
                      ImageUrl = author.Image.Url,
                      Genres = string.Join("/", author.Genres.Select(x => x.Name)),
                      Books = author.Books.Select(book => new AuthorBooksViewModel
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

            var series = this.repositorySeries.AllAsNoTracking().Where(x => x.AuthorId == id).Select(x => new AuthorSeriesViewModel
            {
                SeriesName = x.Name,
                Books = x.Books.Select(s => new AuthorSeriesBooksViewModel
                {
                     ImageExtension = s.Image.Extension,
                }).ToList(),
            }).ToList();

            author.Series = series;

            return author;
        }
    }
}

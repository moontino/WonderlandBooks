namespace WonderlandBooks.Services.Data.ControllerServiceData
{
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ViewModelData;

    public class GetAuthorById : IGetAuthorById
    {
        private readonly IRepository<Author> repositoryAuthor;
        private readonly IRepository<Book> repositoryBook;

        public GetAuthorById(IRepository<Author> repositoryAuthor, IRepository<Book> repositoryBook)
        {
            this.repositoryAuthor = repositoryAuthor;
            this.repositoryBook = repositoryBook;
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
                    Genres = author.Genres.Select(c => c.Name).ToString(),
                    Books = author.Books.Select(book => new AuthorBooksViewModel
                    {
                        Id = book.Id,
                        Name = book.Name,
                        ImageUrl = book.Image.Url,
                        Description = book.Description,
                        EditionLanguageName = book.EditionLanguage.Name,
                        Pages = book.Pages,
                        BookUrl = book.BookUrl,
                        Genres = book.Genres.Select(c => c.Name).ToString(),
                        Characters = book.Characters.Select(c => c.Name).ToString(),
                    }).ToList(),
                }).First(x => x.Id == id);

            return author;
        }
    }
}

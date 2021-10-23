namespace WonderlandBooks.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Models;

    public class GoodreadsDataService : IGoodreadsDataService
    {
        private readonly IGoodreadsScraperService goodreadsScraper;
        private readonly IRepository<Author> authorRepository;
        private readonly IRepository<Book> bookRepository;
        private readonly IRepository<BookSeries> bookSeriesRepository;
        private readonly IRepository<Character> characterRepository;
        private readonly IRepository<EditionLanguage> languageRepository;
        private readonly IRepository<Genre> genreRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public GoodreadsDataService(
            IGoodreadsScraperService goodreadsScraper,
            IRepository<Author> authorRepository,
            IRepository<Book> bookRepository,
            IRepository<BookSeries> bookSeriesRepository,
            IRepository<Character> characterRepository,
            IRepository<EditionLanguage> languageRepository,
            IRepository<Genre> genreRepository,
            IDeletableEntityRepository<Image> imageRepository)
        {
            this.goodreadsScraper = goodreadsScraper;
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
            this.bookSeriesRepository = bookSeriesRepository;
            this.characterRepository = characterRepository;
            this.languageRepository = languageRepository;
            this.genreRepository = genreRepository;
            this.imageRepository = imageRepository;
        }

        public async Task ImportDataAsync(int fromId, int toId)
        {
            var concurrentBag = this.goodreadsScraper.ConcurrentBag(fromId, toId);

            foreach (var model in concurrentBag)
            {
                var authorQuery = this.authorRepository.AllAsNoTracking()
                    .Where(x => x.Name == model.AuthorName)
                    .FirstOrDefault();

                if (authorQuery != null)
                {
                    continue;
                }

                var author = new Author
                {
                    Name = model.AuthorName,
                    Website = model.AuthorWebsite,
                    Biography = model.AuthorBiography,
                };

                var authorImage = new Image
                {
                    Extension = model.AuthorImage,
                    Url = model.AuthorImage,
                };

                author.Image = authorImage;

                await this.imageRepository.AddAsync(authorImage);

                foreach (var genre in model.AuthorGenre)
                {
                    author.Genres.Add(await this.GetOrCreateGenreAsync(genre));
                }

                foreach (var book in model.AuthorBooks)
                {
                    if (book.BookSeriesName != null)
                    {
                        author.BookSeries.Add(await this.GetOrCreateSeriesAsync(book));
                    }

                    author.Books.Add(await this.GetOrCreateBookAsync(book));
                }

                await this.authorRepository.AddAsync(author);
                await this.authorRepository.SaveChangesAsync();
            }
        }

        private async Task<BookSeries> GetOrCreateSeriesAsync(BookDto bookDto)
        {
            var series = this.bookSeriesRepository.All()
                .Where(x => x.Name == bookDto.BookSeriesName)
               .FirstOrDefault();

            if (series != null)
            {
                return series;
            }

            series = new BookSeries
            {
                Name = bookDto.BookSeriesName,
            };

            series.Books.Add(await this.GetOrCreateBookAsync(bookDto));

            return series;
        }

        private async Task<Book> GetOrCreateBookAsync(BookDto bookDto)
        {
            var book = this.bookRepository.All()
                .Where(x => x.Name == bookDto.BookName)
                .FirstOrDefault();

            if (book != null)
            {
                return book;
            }

            book = new Book
            {
                Name = bookDto.BookName,
                Description = bookDto.BookDiscription,
                Pages = bookDto.BookPages,
                BookUrl = bookDto.BookUrl,
                NumberOfSet = bookDto.BookNumberOfSet,
            };

            var bookImage = new Image
            {
                Url = bookDto.BookUrl,
                Extension = bookDto.BookImage,
            };
            await this.imageRepository.AddAsync(bookImage);

            book.Image = bookImage;
            book.EditionLanguage = await this.GetOrCreateEditionLanguageAsync(bookDto.BookEditionLanguage);

            foreach (var genre in bookDto.BookGenre)
            {
                book.Genres.Add(await this.GetOrCreateGenreAsync(genre));
            }

            foreach (var character in bookDto.BookCharacters)
            {
                book.Characters.Add(await this.GetOrCreateCharacterAsync(character));
            }

            await this.bookRepository.AddAsync(book);
            return book;
        }

        private async Task<Character> GetOrCreateCharacterAsync(string characterName)
        {
            var character = this.characterRepository.All()
                .Where(x => x.Name == characterName)
                .FirstOrDefault();

            if (character != null)
            {
                return character;
            }

            character = new Character
            {
                Name = characterName,
            };

            await this.characterRepository.AddAsync(character);
            return character;
        }

        private async Task<EditionLanguage> GetOrCreateEditionLanguageAsync(string languageName)
        {
            var language = this.languageRepository.All()
                .Where(x => x.Name == languageName.Trim())
                .FirstOrDefault();

            if (language != null)
            {
                return language;
            }

            language = new EditionLanguage
            {
                Name = languageName,
            };

            await this.languageRepository.AddAsync(language);
            await this.languageRepository.SaveChangesAsync();
            return language;
        }

        private async Task<Genre> GetOrCreateGenreAsync(string genreName)
        {
            var genre = this.genreRepository
                 .All()
                 .FirstOrDefault(x => x.Name == genreName);

            if (genre != null)
            {
                return genre;
            }

            genre = new Genre
            {
                Name = genreName,
            };
            await this.genreRepository.AddAsync(genre);
            await this.genreRepository.SaveChangesAsync();
            return genre;
        }
    }
}

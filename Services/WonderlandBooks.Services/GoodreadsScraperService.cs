namespace WonderlandBooks.Services
{
    using System.Threading.Tasks;

    using AngleSharp;
    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class GoodreadsScraperService : IGoodreadsScraperService
    {
        private readonly IBrowsingContext context;
        private readonly IRepository<Author> authorRepository;
        private readonly IRepository<Book> bookRepository;
        private readonly IRepository<Character> characterRepository;
        private readonly IRepository<EditionLanguage> languageRepository;
        private readonly IRepository<Genre> genreRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public GoodreadsScraperService(
            IRepository<Author> authorRepository,
            IRepository<Book> bookRepository,
            IRepository<Character> characterRepository,
            IRepository<EditionLanguage> languageRepository,
            IRepository<Genre> genreRepository,
            IDeletableEntityRepository<Image> imageRepository)
        {
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
            this.characterRepository = characterRepository;
            this.languageRepository = languageRepository;
            this.genreRepository = genreRepository;
            this.imageRepository = imageRepository;

            var config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(config);
        }

        public IRepository<Genre> GenreRepository { get; }

        public Task ImportAuthorsWithBookAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}

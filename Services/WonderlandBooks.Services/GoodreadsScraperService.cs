namespace WonderlandBooks.Services
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using AngleSharp.Dom;
    using WonderlandBooks.Services.Models;

    public class GoodreadsScraperService : IGoodreadsScraperService
    {
        private const string BaseUrl = "https://www.goodreads.com{0}{1}";
        private const string AuthorShowPath = "/author/show/";
        private const string AuthorListPath = "/author/list/";
        private const string AuthorDefaultProfileImage = "https://st3.depositphotos.com/13159112/17145/v/600/depositphotos_171453724-stock-illustration-default-avatar-profile-icon-grey.jpg";

        private readonly IBrowsingContext context;

        public GoodreadsScraperService()
        {
            var config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(config);
        }

        public ConcurrentBag<AuthorBooksDto> ConcurrentBag(int fromId, int toId)
        {
            var concurrentBag = new ConcurrentBag<AuthorBooksDto>();
            Parallel.For(fromId, toId + 1, i =>
            {
                try
                {
                    var authorBook = this.GetAuthor(i);
                    concurrentBag.Add(authorBook);
                }
                catch
                {
                }
            });
            return concurrentBag;
        }

        private AuthorBooksDto GetAuthor(int id)
        {
            var authorUrl = string.Format(BaseUrl, AuthorShowPath, id);

            var model = new AuthorBooksDto();

            var author = this.context.OpenAsync(authorUrl)
                .GetAwaiter()
                .GetResult();

            model.AuthorName = author.QuerySelectorAll(".authorName > span")
                .First()
                .TextContent
                .Trim();

            var authorWebsite = author.QuerySelectorAll(".dataItem > a")
                .Attr("href")
                .FirstOrDefault();

            if (authorWebsite == null)
            {
                authorWebsite = authorUrl;
            }

            model.AuthorWebsite = authorWebsite;

            var authorBiography = author.QuerySelectorAll(".aboutAuthorInfo > span")
                .FirstOrDefault();
            if (authorBiography == null || string.IsNullOrEmpty(authorBiography.TextContent))
            {
                throw new InvalidOperationException("Author Biography is null");
            }

            model.AuthorBiography = authorBiography.TextContent;

            var authorImage = author.QuerySelectorAll(".reverseColumnSizes > div > a > img")
                 .Attr("src")
                 .FirstOrDefault();
            if (authorImage == null)
            {
                model.AuthorImage = AuthorDefaultProfileImage;
            }
            else
            {
                model.AuthorImage = authorImage;
            }

            var authorGenres = author.QuerySelectorAll(".dataItem > a")
                .Where(x => x.HasAttribute("href"));

            foreach (var genre in authorGenres)
            {
                var tempCharArray = genre.TextContent.ToCharArray();
                if (genre.TextContent == authorWebsite || char.IsLower(tempCharArray[0]))
                {
                    continue;
                }

                model.AuthorGenre.Add(genre.TextContent);
            }

            var authorListUrl = string.Format(BaseUrl, AuthorListPath, id);

            var authorBooks = this.context.OpenAsync(authorListUrl)
                .GetAwaiter()
                .GetResult();

            var urlBooksName = authorBooks.QuerySelectorAll(".bookTitle").Attr("href");
            foreach (var bookUrl in urlBooksName)
            {
                try
                {
                    var book = this.GetBook(bookUrl);
                    model.AuthorBooks.Add(book);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            if (model.AuthorBooks.Count < 1)
            {
                throw new InvalidOperationException();
            }

            return model;
        }

        private BookDto GetBook(string bookUrl)
        {
            var url = string.Format(BaseUrl, bookUrl, string.Empty);
            var book = new BookDto();

            var documentUrl = this.context.OpenAsync(url)
                .GetAwaiter()
                .GetResult();

            book.BookUrl = url;
            var curBookName = documentUrl.QuerySelectorAll("h1")
                   .Where(x => x.Id == "bookTitle")
                   .FirstOrDefault();
            if (curBookName == null || string.IsNullOrEmpty(curBookName.TextContent))
            {
                throw new InvalidOperationException("Book name is null");
            }

            book.BookName = curBookName
                .TextContent
                .Trim();

            var bookDescription = documentUrl.QuerySelectorAll(".readable > span")
                .Take(2);

            if (bookDescription == null || bookDescription.Any(x => string.IsNullOrEmpty(x.TextContent)))
            {
                throw new InvalidOperationException("Description is null");
            }

            foreach (var description in bookDescription)
            {
                book.BookDiscription += description.TextContent;
            }

            book.BookPages = int.Parse(documentUrl.QuerySelectorAll(".uitext > div > span")
                .Skip(1)
                .First()
                .TextContent
                .Replace("pages", string.Empty)
                .TrimEnd());

            var bookNumberOfSetAndBookSeries = documentUrl.QuerySelectorAll(".last > h2")
                .FirstOrDefault().TextContent;

            if (bookNumberOfSetAndBookSeries != null)
            {
                var bookPairSetAndSeries = bookNumberOfSetAndBookSeries
                    .Trim()
                    .Replace(")", string.Empty)
                    .Replace("(", string.Empty)
                    .Split("#");
                if (bookPairSetAndSeries.Count() > 1)
                {
                    book.BookSeriesName = bookPairSetAndSeries[0].TrimEnd();
                    book.BookNumberOfSet = int.Parse(bookPairSetAndSeries[1]);
                }
            }

            book.BookImage = documentUrl.QuerySelectorAll(".bookCoverPrimary > a > img")
                .Attr("src")
                .FirstOrDefault();

            var bookLanguage = documentUrl.QuerySelectorAll(".clearFloats")
               .Where(x => x.Children.HasClass("infoBoxRowItem"))
               .FirstOrDefault(x => x.TextContent.Contains("Edition Language"));

            if (bookLanguage == null)
            {
                throw new InvalidOperationException("Language is null");
            }

            book.BookEditionLanguage = bookLanguage.TextContent
                .Replace("Edition Language", string.Empty)
                .Trim();

            var bookGenders = documentUrl.QuerySelectorAll(".left > a");

            foreach (var genre in bookGenders)
            {
                book.BookGenre.Add(genre.TextContent);
            }

            var bookCharactersQuery = documentUrl.QuerySelectorAll(".clearFloats")
                .Where(x => x.Children.HasClass("infoBoxRowItem"))
                .FirstOrDefault(x => x.TextContent.Contains("Characters"));

            if (bookCharactersQuery != null)
            {
                var bookCharacters = bookCharactersQuery
              .TextContent.Replace("Characters", string.Empty)
              .Trim();

                book.BookCharacters.Add(bookCharacters);
            }

            return book;
        }
    }
}

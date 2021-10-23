namespace WonderlandBooks.Services
{
    using System.Collections.Concurrent;

    using WonderlandBooks.Services.Models;

    public interface IGoodreadsScraperService
    {
        ConcurrentBag<AuthorBooksDto> ConcurrentBag(int fromId, int toId);
    }
}

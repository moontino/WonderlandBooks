namespace WonderlandBooks.Services
{
    using System.Threading.Tasks;

    public interface IGoodreadsScraperService
    {
        Task ImportAuthorsWithBookAsync();
    }
}

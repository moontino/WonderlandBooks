namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public interface IStoriesService
    {
        T All<T>(string id);
    }
}

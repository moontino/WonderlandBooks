namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public interface IPostService
    {
        T ById<T>(int id);
    }
}

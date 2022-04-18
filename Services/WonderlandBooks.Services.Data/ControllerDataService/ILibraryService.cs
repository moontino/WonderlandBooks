namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public interface ILibraryService
    {
        bool IsBookInUserLibrary(int bookId, string userId);

        void Test(int bookId, string userId);
    }
}

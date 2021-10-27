namespace WonderlandBooks.Services.Data.ViewModelServiceData
{
    public interface IAuthorBiographyCutLengthService
    {
        (string FirstPart, string SecondPard) Cut(string text);
    }
}

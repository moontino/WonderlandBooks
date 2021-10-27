namespace WonderlandBooks.Services.Data.ViewModelServiceData
{
    public class AuthorBiographyCutLengthService : IAuthorBiographyCutLengthService
    {
        public (string FirstPart, string SecondPard) Cut(string text)
        {
            string partOne, partSecond;

            if (text.Length < 50)
            {
                partOne = text.Substring(0, 9);
                partSecond = text.Substring(9, text.Length);

                return (partOne, partSecond);
            }

            partOne = text.Substring(0, 49);
            partSecond = text.Substring(49, text.Length);

            return (partOne, partSecond);
        }
    }
}

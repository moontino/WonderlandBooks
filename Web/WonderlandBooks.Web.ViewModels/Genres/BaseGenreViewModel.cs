namespace WonderlandBooks.Web.ViewModels.Genres
{
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class BaseGenreViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

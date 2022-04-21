namespace WonderlandBooks.Web.ViewModels.Genres
{
    using System.Collections.Generic;

    public class GenrePostViewModel : BaseGenreViewModel
    {
        public IEnumerable<PostViewModel> FormPost { get; set; }
    }
}

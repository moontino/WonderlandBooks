namespace WonderlandBooks.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class GenrePostViewModel : BaseGenreViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}

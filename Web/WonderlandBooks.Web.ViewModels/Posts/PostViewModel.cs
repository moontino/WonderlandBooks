namespace WonderlandBooks.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public IEnumerable<PostComentsViewModel> Comments { get; set; }
    }
}

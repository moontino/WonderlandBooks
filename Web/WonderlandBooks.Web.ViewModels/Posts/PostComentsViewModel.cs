namespace WonderlandBooks.Web.ViewModels.Posts
{
    using System;

    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class PostComentsViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}

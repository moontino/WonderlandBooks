namespace WonderlandBooks.Web.ViewModels.Posts
{
    using System;

    using Ganss.XSS;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class PostComentsViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}

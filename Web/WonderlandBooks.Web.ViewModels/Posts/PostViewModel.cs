namespace WonderlandBooks.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Ganss.XSS;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>,IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<PostComentsViewModel> Coments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.VotesCount, y =>
                {
                    y.MapFrom(v => v.Votes.Sum(c => (int)c.Type));
                });
        }
    }
}

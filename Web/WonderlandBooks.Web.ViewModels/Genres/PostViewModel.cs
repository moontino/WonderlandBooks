namespace WonderlandBooks.Web.ViewModels.Genres
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>().ForMember(
              x => x.Content,
              y => y.MapFrom(x => x.Content.Length > 100
              ? WebUtility.HtmlDecode(Regex.Replace(x.Content, @"<[^>]+>", string.Empty)).Substring(0, 100) + "..."
              : WebUtility.HtmlDecode(Regex.Replace(x.Content, @"<[^>]+>", string.Empty))));
        }
    }
}

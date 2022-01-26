namespace WonderlandBooks.Web.ViewModels.Authors
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AuthorViewModel : IMapFrom<Author>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Biography { get; set; }

        public string ImageUrl { get; set; }

        public string Genres { get; set; }

        public IEnumerable<AuthorBooksViewModel> Books { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Author, AuthorViewModel>().ForMember(
               x => x.Genres,
               y => y.MapFrom(x => string.Join("/", x.Genres.Select(x => x.Name))));
        }
    }
}

namespace WonderlandBooks.Web.ViewModels.Recommendations
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class RecommendationsViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Genres { get; set; }

        public IEnumerable<RecommendationsAuthorsViewModel> Authors { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, RecommendationsViewModel>().ForMember(
              x => x.Genres,
              y => y.MapFrom(x => string.Join("/", x.Genres.Select(x => x.Name))));
        }
    }
}

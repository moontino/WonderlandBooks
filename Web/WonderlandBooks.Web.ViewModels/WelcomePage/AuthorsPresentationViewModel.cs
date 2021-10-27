namespace WonderlandBooks.Web.ViewModels.WelcomePage
{
    using System.Linq;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AuthorsPresentationViewModel : IMapFrom<Author>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string ImageUrl { get; set; }

        public int Books { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Author, AuthorsPresentationViewModel>().ForMember(
                  m => m.Books,
                  opt => opt.MapFrom(x => x.Books.Count()));
        }
    }
}

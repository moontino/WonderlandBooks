namespace WonderlandBooks.Web.ViewModels.WelcomePage
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class BookPresentationViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Pages { get; set; }

        public string BookUrl { get; set; }

        public string ImageExtension { get; set; }

        public ICollection<string> GenresName { get; set; }

        public ICollection<string> CharactersName { get; set; }

        public ICollection<string> AuthorsName { get; set; }

        public string EditionLanguageName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookPresentationViewModel>().ForMember(
                x => x.GenresName,
                y => y.MapFrom(x => x.Genres.Select(t => t.Name)));
            configuration.CreateMap<Book, BookPresentationViewModel>().ForMember(
                x => x.CharactersName,
                y => y.MapFrom(x => x.Characters.Select(t => t.Name)));
            configuration.CreateMap<Book, BookPresentationViewModel>().ForMember(
               x => x.AuthorsName,
               y => y.MapFrom(x => x.Authors.Select(t => t.Name)));
        }
    }
}

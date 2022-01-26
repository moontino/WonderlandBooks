namespace WonderlandBooks.Web.ViewModels.Books
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class BookViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Pages { get; set; }

        public string BookUrl { get; set; }

        public string ImageUrl { get; set; }

        public string EditionLanguage { get; set; }

        public string Genres { get; set; }

        // public string Characters { get; set; }

        public IEnumerable<BookAuthorViewModel> Authors { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookViewModel>().ForMember(
              x => x.Genres,
              y => y.MapFrom(x => string.Join("/", x.Genres.Select(x => x.Name))));

            // TODO: see how to fix charactesr
            // configuration.CreateMap<Book, BookViewModel>().ForMember(
            //  x => x.Characters,
            //  y => y.MapFrom(t => t.Characters.Count != 0 ? string.Join("/", t.Characters.Select(x => x.Name)) : null));
        }
    }
}

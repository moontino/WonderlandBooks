namespace WonderlandBooks.Web.ViewModels.Books
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class BookViewModel : BasicBookViewModel, IMapFrom<Book>, IHaveCustomMappings
    {
        public string Description { get; set; }

        public int? Pages { get; set; }

        public string BookUrl { get; set; }

        public string EditionLanguage { get; set; }

        public string Genres { get; set; }

        public string Characters { get; set; }

        public string VotesAvarege { get; set; }

        public IEnumerable<BookAuthorViewModel> Authors { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookViewModel>().ForMember(
              x => x.Genres,
              y => y.MapFrom(x => string.Join("/", x.Genres.Select(x => x.Name))))

            .ForMember(
             x => x.Characters,
             y => y.MapFrom(t => t.Characters.Count != 0 ? string.Join("/", t.Characters.Select(x => x.Name)) : null))

             .ForMember(
             x => x.EditionLanguage,
             y => y.MapFrom(t => t.EditionLanguage.Name))

            .ForMember(
               x => x.VotesAvarege,
               y => y.MapFrom(x => x.VoteBooks.Average(x => x.Value) == null? 
               "0.0" : Math.Round(x.VoteBooks.Average(x => x.Value), 1).ToString()));
        }
    }
}

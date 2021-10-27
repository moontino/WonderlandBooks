namespace WonderlandBooks.Web.ViewModels.Authors
{
    using System.Linq;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class TopTenAuthorsByBooksCount : IMapFrom<Author>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Website { get; set; }

        public string Biography { get; set; }

        public string ImageUrl { get; set; }

        // за да достигнем до друга таблица трябва да запепим името е така
        public int Books { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Author, TopTenAuthorsByBooksCount>().ForMember(
                 m => m.Books,
                 opt => opt.MapFrom(x => x.Books.Count()));
        }
    }
}

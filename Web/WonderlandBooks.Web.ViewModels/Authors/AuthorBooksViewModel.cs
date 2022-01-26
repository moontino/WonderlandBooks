namespace WonderlandBooks.Web.ViewModels.Authors
{
    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class AuthorBooksViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string EditionLanguageName { get; set; }
    }
}

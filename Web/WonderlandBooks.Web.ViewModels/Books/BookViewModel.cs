namespace WonderlandBooks.Web.ViewModels.Books
{
    using System.Collections.Generic;

    using WonderlandBooks.Services.Mapping;

    public class BookViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? NumberOfSet { get; set; }

        public string SeriesName { get; set; }

        public int? SeriesId { get; set; }

        public int? Pages { get; set; }

        public string BookUrl { get; set; }

        public string ImageUrl { get; set; }

        public string EditionLanguage { get; set; }

        public string Genres { get; set; }

        public string Characters { get; set; }

        public IList<BookAuthorViewModel> Author { get; set; }

        public IList<BookRecommendationsViewModel> BookRecommendationsByGenre { get; set; }
    }
}

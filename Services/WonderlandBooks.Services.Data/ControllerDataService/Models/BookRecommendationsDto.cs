namespace WonderlandBooks.Services.Data.ControllerDataService.Models
{
    using System.Collections.Generic;

    using WonderlandBooks.Services.Data.ControllerDataService.Models;

    public class BookRecommendationsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public IList<BookRecommendationsAuthorsDto> Authors { get; set; }
    }
}

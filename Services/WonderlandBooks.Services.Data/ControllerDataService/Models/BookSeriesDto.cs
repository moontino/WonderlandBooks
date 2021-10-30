namespace WonderlandBooks.Services.Data.ControllerDataService.Models
{
    using System.Collections.Generic;

    public class BookSeriesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<BookSeriesBooksDto> BooksSeries { get; set; }
    }
}

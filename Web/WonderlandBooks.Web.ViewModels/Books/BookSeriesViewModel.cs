namespace WonderlandBooks.Web.ViewModels.Books
{
    using System.Collections.Generic;

    public class BookSeriesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<BookSeriesBooksViewModel> BooksSeries { get; set; }
    }
}

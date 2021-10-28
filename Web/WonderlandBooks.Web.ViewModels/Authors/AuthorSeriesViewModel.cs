namespace WonderlandBooks.Web.ViewModels.Authors
{
    using System.Collections.Generic;

    public class AuthorSeriesViewModel
    {
        public string SeriesName { get; set; }

        public IList<AuthorSeriesBooksViewModel> Books { get; set; }
    }
}

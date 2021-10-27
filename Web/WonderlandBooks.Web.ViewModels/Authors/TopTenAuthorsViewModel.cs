namespace WonderlandBooks.Web.ViewModels.Authors
{
    using System.Collections.Generic;

    public class TopTenAuthorsViewModel
    {
        public IEnumerable<TopTenAuthorsByBooksCount> Authors { get; set; }
    }
}

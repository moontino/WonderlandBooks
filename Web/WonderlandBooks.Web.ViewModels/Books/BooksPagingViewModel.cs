using System;
using System.Collections.Generic;

namespace WonderlandBooks.Web.ViewModels.Books
{
    public class BooksPagingViewModel : BasicPaging
    {
        public IEnumerable<BooksListViewModel> Books { get; set; }

        public string SearchString { get; set; }
    }
}

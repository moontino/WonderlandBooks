using System.Collections.Generic;

namespace WonderlandBooks.Web.ViewModels.Books
{
    public class RandomListBookViewModel
    {
        public BookViewModel Book { get; set; }

        public IEnumerable<BooksListViewModel> RandomBooks { get; set; }
    }
}

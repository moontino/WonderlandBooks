using System;
using System.Collections.Generic;

namespace WonderlandBooks.Web.ViewModels.Books
{
    public class BookListPagingViewModel
    {
        public IEnumerable<BooksListViewModel> Books { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.BooksCount / this.ItemPerPage);

        public int BooksCount { get; set; }

        public int ItemPerPage { get; set; }
    }
}

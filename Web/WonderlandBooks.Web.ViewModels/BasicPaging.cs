using System;

namespace WonderlandBooks.Web.ViewModels
{
    public abstract class BasicPaging
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.Count / this.ItemPerPage);

        public int Count { get; set; }

        public int ItemPerPage { get; set; }
    }
}

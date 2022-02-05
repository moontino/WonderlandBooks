using System;
using System.Collections.Generic;
using System.Text;

namespace WonderlandBooks.Web.ViewModels.Authors
{
    public class AuthorsPagingViewModel : BasicPaging
    {
        public IEnumerable<AuthorsListViewModel> Authors { get; set; }
    }
}

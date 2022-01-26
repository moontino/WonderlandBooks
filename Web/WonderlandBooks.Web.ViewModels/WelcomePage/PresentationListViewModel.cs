using System;
using System.Collections.Generic;
using System.Text;

namespace WonderlandBooks.Web.ViewModels.WelcomePage
{
   public class PresentationListViewModel
    {
        public IList<AuthorsPresentationViewModel> Authors { get; set; }

        public IList<BookPresentationViewModel> Book { get; set; }
    }
}

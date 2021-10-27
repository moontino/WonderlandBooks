namespace WonderlandBooks.Web.ViewModels.WelcomePage
{
    using System.Collections.Generic;

    public class AuthorsAndBooksPresentationListViewModel
    {
        public IList<AuthorsPresentationViewModel> Authors { get; set; }

        public IList<BookPresentationViewModel> Book { get; set; }
    }
}

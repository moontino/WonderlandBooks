namespace WonderlandBooks.Web.ViewModels.Books
{
    using System.Collections.Generic;

    public class ListOfBooksLibraryViewModel
    {
        public string Id { get; set; }

        public ICollection<LibraryBooksViewModel> Shelves { get; set; }
    }
}

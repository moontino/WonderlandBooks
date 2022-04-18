namespace WonderlandBooks.Web.ViewModels.Books
{
    using System.Collections.Generic;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class ListOfBooksLibraryViewModel:IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public ICollection<LibraryBooksViewModel> Shelves { get; set; }
    }
}

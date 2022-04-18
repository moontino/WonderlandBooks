using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.Books
{
    public class LibraryBooksViewModel : IMapFrom<Shelf>
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string BookImageUrl { get; set; }

        public ReadType ReadType { get; set; }
    }
}

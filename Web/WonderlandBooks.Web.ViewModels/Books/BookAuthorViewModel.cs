using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.Books
{
    public class BookAuthorViewModel:IMapFrom<Author>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

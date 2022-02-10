using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.Home
{
    public class HomeBooksViewModel:IMapFrom<Book>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }
    }
}

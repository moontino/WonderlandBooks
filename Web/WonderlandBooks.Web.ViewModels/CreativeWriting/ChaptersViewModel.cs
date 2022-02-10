using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    public class ChaptersViewModel : IMapFrom<Chapter>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}

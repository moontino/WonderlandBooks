using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.Recommendations
{
    public class RecommendationsAuthorsViewModel : IMapFrom<Author>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

using AutoMapper;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    public class StoriesViewModel : IMapFrom<Story>,IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            // Image = s.Image.Url ?? "/images/stories/" + s.Image.Id + s.Image.Extension,

        }
    }
}

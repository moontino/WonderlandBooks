using AutoMapper;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    public class StoriesViewModel : IMapFrom<Story>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}

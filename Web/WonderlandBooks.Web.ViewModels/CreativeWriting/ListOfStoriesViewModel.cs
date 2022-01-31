using AutoMapper;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    public class ListOfStoriesViewModel : IMapFrom<Story>// , IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

       //public void CreateMappings(IProfileExpression configuration)
       //{
       //    configuration.CreateMap<Story, ListOfStoriesViewModel>()
       //        .ForMember(x => x.Image, opt =>
       //            opt.MapFrom(x => x.Image.Url != null ? x.Image.Url
       //            : ("/images/stories/" + x.Image.Id + x.Image.Extension)));
       //}
    }
}

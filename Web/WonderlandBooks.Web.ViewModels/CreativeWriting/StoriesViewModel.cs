namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class StoriesViewModel : BaseStoryViewModel, IMapFrom<Story>, IHaveCustomMappings
    {
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Story, StoriesViewModel>()
              .ForMember(x => x.Image, opt => opt
              .MapFrom(x => x.Image.Url ?? "/images/stories/" + x.Image.Id + x.Image.Extension))

              .ForMember(x => x.Description, opt => opt
              .MapFrom(x => x.Description == null ? "..." : x.Description
              .Substring(0, x.Description.Length <= 500 ? x.Description.Length : 500)));
        }
    }
}

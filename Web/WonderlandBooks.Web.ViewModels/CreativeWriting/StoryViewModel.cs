namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class StoryViewModel : IMapFrom<Story>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string GenreName { get; set; }

        public string EditionLanguageName { get; set; }

        public IList<ChaptersViewModel> Chapters { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Story, StoryViewModel>()
              .ForMember(x => x.Image, opt => opt
              .MapFrom(x => x.Image.Url ?? "/images/stories/" + x.Image.Id + x.Image.Extension));
        }
    }
}

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;

    using AutoMapper;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class StoryViewModel : BaseStoryViewModel, IMapFrom<Story>, IHaveCustomMappings
    {
        public string GenreName { get; set; }

        public string GenreId { get; set; }

        public string EditionLanguageName { get; set; }

        public string EditionLanguageId { get; set; }

        public IList<ChaptersViewModel> Chapters { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Story, StoryViewModel>()
              .ForMember(x => x.Image, opt => opt
              .MapFrom(x => x.Image.Url ?? "/images/stories/" + x.Image.Id + x.Image.Extension));
        }
    }
}

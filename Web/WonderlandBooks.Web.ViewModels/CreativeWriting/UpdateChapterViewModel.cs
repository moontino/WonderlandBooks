namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;

    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class UpdateChapterViewModel : IMapFrom<Chapter>,IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title must contain at least 3 characters")]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description must contain at least 20 characters")]
        [MinLength(20)]
        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Chapter, UpdateChapterViewModel>()
             .ForMember(x => x.Name, opt => opt
             .MapFrom(x => x.Title));
        }
    }
}

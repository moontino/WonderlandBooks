namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class UpdateStoryViewModel : IMapFrom<Story>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "The title must contain at least 3 characters")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description must contain at least 20 characters")]
        [MinLength(20)]
        public string Description { get; set; }

        public string Image { get; set; }

        public IFormFile NewImage { get; set; }

        public string GenreName { get; set; }

        [Display(Name = "Genre")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a genre")]
        public int GenreId { get; set; }

        public string EditionLanguageName { get; set; }

        [Display(Name = "Language")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a language")]

        public int EditionLanguageId { get; set; }

        public int CreativeWritingId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Story, UpdateStoryViewModel>()
              .ForMember(x => x.Image, opt => opt
              .MapFrom(x => x.Image.Url ?? "/images/stories/" + x.Image.Id + x.Image.Extension));
        }
    }
}

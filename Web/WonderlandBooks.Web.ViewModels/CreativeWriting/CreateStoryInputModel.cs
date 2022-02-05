namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateStoryInputModel
    {
        [Required(ErrorMessage = "The title must contain at least 3 characters")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description must contain at least 20 characters")]
        [MinLength(20)]
        public string Description { get; set; }
   
        public IFormFile Image { get; set; }

        [Display(Name = "Genre")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a genre")]
        public int GenreId { get; set; }

        [Display(Name = "Language")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a language")]
        public int EditionLanguageId { get; set; }

        public string UserId { get; set; }

        public IList<string> Characters { get; set; }

        public IList<string> Tags { get; set; }
    }
}

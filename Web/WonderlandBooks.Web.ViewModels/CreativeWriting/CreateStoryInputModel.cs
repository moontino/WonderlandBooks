namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CreateStoryInputModel
    {
        [Required(ErrorMessage = "The title must contain at least 3 characters")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description must contain at least 20 characters")]
        [MinLength(20)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }// custom attribute


        [Range(1, int.MaxValue, ErrorMessage = "Please select a genre")]
        public int GenreId { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Please select a language")]
        public int EditionLanguageId { get; set; }

        // Characters,Tags????
    }
}

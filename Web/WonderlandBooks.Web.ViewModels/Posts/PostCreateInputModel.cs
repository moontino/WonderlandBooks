namespace WonderlandBooks.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    public class PostCreateInputModel
    {
        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "The Title must contain at least 3 characters")]
        public string Title { get; set; }

        [MinLength(10)]
        [MaxLength(2000)]
        [Required(ErrorMessage = "The description must contain at least 10 characters")]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Genre")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a genre")]
        public int GenreId { get; set; }
    }
}

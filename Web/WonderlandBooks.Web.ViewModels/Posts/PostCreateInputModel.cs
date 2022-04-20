namespace WonderlandBooks.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    public class PostCreateInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(600)]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public int GenreId { get; set; }
    }
}

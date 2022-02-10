namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.ComponentModel.DataAnnotations;

    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class UpdateChapterViewModel:IMapFrom<Chapter>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title must contain at least 3 characters")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description must contain at least 20 characters")]
        [MinLength(20)]
        public string Description { get; set; }
    }
}

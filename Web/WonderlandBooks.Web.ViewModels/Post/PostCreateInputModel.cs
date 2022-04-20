using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderlandBooks.Web.ViewModels.Post
{
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    public class BaseChapterViewModel : IMapFrom<Chapter>
    {
        [Required(ErrorMessage = "The title must contain at least 3 characters")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description must contain at least 20 characters and less that 30000")]
        [MinLength(20)]
        [MaxLength(30000)]
        public string Description { get; set; }
    }
}

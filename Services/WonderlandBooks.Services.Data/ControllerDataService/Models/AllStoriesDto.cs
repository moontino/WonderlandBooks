using System.Collections.Generic;

namespace WonderlandBooks.Services.Data.ControllerDataService.Models
{
    public class AllStoriesDto
    {
        public string UserId { get; set; }

        public ICollection<ListOfStoriesDto> Stories { get; set; }
    }
}

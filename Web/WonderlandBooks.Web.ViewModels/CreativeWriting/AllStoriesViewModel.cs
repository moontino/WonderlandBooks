namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;

    using WonderlandBooks.Services.Mapping;

    public class AllStoriesViewModel : BasicPaging, IMapFrom<WonderlandBooks.Data.Models.CreativeWriting>
    {
        public IEnumerable<StoriesViewModel> Stories { get; set; }
    }
}

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;

    using WonderlandBooks.Services.Mapping;

    public class CollectionOfStories :BasicPaging, IMapFrom<WonderlandBooks.Data.Models.CreativeWriting>
    {
        public string UserId { get; set; }

        public IEnumerable<StoriesViewModel> StoriesStorage { get; set; }
    }
}

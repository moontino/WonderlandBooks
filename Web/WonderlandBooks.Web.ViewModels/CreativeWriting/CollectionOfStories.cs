namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;

    using WonderlandBooks.Services.Mapping;

    public class CollectionOfStories : IMapFrom<WonderlandBooks.Data.Models.CreativeWriting>
    {
        public string UserId { get; set; }


        public ICollection<StoriesViewModel> Stories { get; set; }
    }
}

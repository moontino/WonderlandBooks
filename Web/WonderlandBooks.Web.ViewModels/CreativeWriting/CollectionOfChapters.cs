namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;

    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class CollectionOfChapters : IMapFrom<Story>
    {
        public int Id { get; set; }

        public IEnumerable<ChaptersViewModel> Chapters { get; set; }
    }
}

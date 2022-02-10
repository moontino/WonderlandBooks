using System.Collections.Generic;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    public class CollectionOfChapters : IMapFrom<Story>
    {
        public int Id { get; set; }

        public IEnumerable<ChaptersViewModel> Chapters { get; set; }
    }
}

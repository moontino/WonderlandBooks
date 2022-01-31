using System.Collections.Generic;
using WonderlandBooks.Services.Data.ControllerDataService.Models;
using WonderlandBooks.Web.ViewModels.CreativeWriting;

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public interface IStoriesService
    {
        CollectionOfStories All(string id);
    }
}

﻿namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;

    using WonderlandBooks.Services.Data.ControllerDataService.Models;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public interface IGetStoriesService
    {
        CollectionOfStories All(string id);

        T CurrentStory<T>(int storyId);
    }
}

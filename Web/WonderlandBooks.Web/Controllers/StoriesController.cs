﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WonderlandBooks.Services.Data.InputDataServices;

namespace WonderlandBooks.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : BaseController
    {
        private readonly IModifiedChapterService chapterService;
        private readonly IModifiedStoryService storyService;

        public StoriesController(IModifiedChapterService chapterService, IModifiedStoryService storyService)
        {
            this.chapterService = chapterService;
            this.storyService = storyService;
        }

        [Authorize]
        [HttpPost("delete/chapter/{id}")]
        public async Task<ActionResult<int>> RemoveChapter(int id)
        {
            await this.chapterService.RemoveAsync(id);
            return id;
        }

        [Authorize]
        [HttpPost("delete/story/{id}")]
        public async Task<ActionResult<int>> RemoveStory(int id)
        {
            await this.storyService.RemoveAsync(id);
            return id;
        }
    }
}

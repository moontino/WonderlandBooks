namespace WonderlandBooks.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Services.Data.InputDataServices;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;
    using WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList;

    public class CreativeWritingController : BaseController
    {
        private readonly IGenreInputModelListItems genreInputModel;
        private readonly IEditionLanguageInputModelListItems editionLanguageInputModel;
        private readonly IMapper mapper;
        private readonly IModifiedStoryService storyService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IStoriesService stories;
        private readonly IModifiedChapterService modifiedChapterService;
        private readonly IChapterService chapterService;

        public CreativeWritingController(
            IGenreInputModelListItems genreInputModel,
            IEditionLanguageInputModelListItems editionLanguageInputModel,
            IMapper mapper,
            IModifiedStoryService modifiedStoryService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment hostEnvironment,
            IStoriesService storiesService,
            IModifiedChapterService modifiedChapterService,
            IChapterService chapterService)
        {
            this.genreInputModel = genreInputModel;
            this.editionLanguageInputModel = editionLanguageInputModel;
            this.mapper = mapper;
            this.storyService = modifiedStoryService;
            this.userManager = userManager;
            this.hostEnvironment = hostEnvironment;
            this.stories = storiesService;
            this.modifiedChapterService = modifiedChapterService;
            this.chapterService = chapterService;
        }

        public IActionResult AllStories(int id = 1)
        {
            const int ItemPerPage = 8;
            var model = new AllStoriesViewModel
            {
                ItemPerPage = ItemPerPage,
                PageNumber = id,
                Count = this.stories.GetCount(),
                Stories = this.stories.AllStories<StoriesViewModel>(id, ItemPerPage),
            };

            return this.View(model);
        }

        public IActionResult CurrentStory(int id)
        {
            var model = this.mapper.Map<StoryViewModel>(this.stories.CurrentStory<StoryViewModel>(id));
            return this.View(model);
        }

        [Authorize]
        public async Task<IActionResult> StoriesByUser()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.mapper.Map<CollectionOfStories>(this.stories.StoriesByUser<CollectionOfStories>(user.Id));
            return this.View(model);
        }

        [Authorize]
        public IActionResult CreateStory()
        {
            this.ViewBag.Genres = new SelectList(this.genreInputModel.Options, "Value", "Text");
            this.ViewBag.Language = new SelectList(this.editionLanguageInputModel.Options, "Value", "Text");

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateStory(CreateStoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewBag.Genres = new SelectList(this.genreInputModel.Options, "Value", "Text");
                this.ViewBag.Language = new SelectList(this.editionLanguageInputModel.Options, "Value", "Text");
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            input.UserId = user.Id;

            var path = this.hostEnvironment.WebRootPath;
            await this.storyService.CreateAsync(input, path);

            return this.Redirect("StoriesByUser");
        }

        [Authorize]
        public IActionResult UpdateStory(int idStory)
        {
            this.ViewBag.Genres = new SelectList(this.genreInputModel.Options, "Value", "Text");
            this.ViewBag.Language = new SelectList(this.editionLanguageInputModel.Options, "Value", "Text");

            var model = this.mapper.Map<UpdateStoryViewModel>(this.stories.CurrentStory<UpdateStoryViewModel>(idStory));

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateStory(UpdateStoryViewModel input, string imagePath)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewBag.Genres = new SelectList(this.genreInputModel.Options, "Value", "Text");
                this.ViewBag.Language = new SelectList(this.editionLanguageInputModel.Options, "Value", "Text");
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            input.UserId = user.Id;

            var path = this.hostEnvironment.WebRootPath;
            await this.storyService.UpdateAsync(input, imagePath, path);

            return this.RedirectToAction("StoriesByUser");
        }

        [Authorize]
        public IActionResult CreateChapter(int idStory)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(idStory);
            }

            CreateChapterInputModel model = new CreateChapterInputModel
            {
                StoryId = idStory,
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateChapter(CreateChapterInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("AddChapter");
            }

            await this.modifiedChapterService.CreateAsync(input);

            return this.RedirectToAction("StoriesByUser");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateChapter(UpdateChapterViewModel input, int id)
        {
            await this.modifiedChapterService.UpdateAsync(input);
            return this.RedirectToAction("StoriesByUser");
        }

        [Authorize]
        [Route("SelectChapter/{id:int}")]
        public IActionResult SelectChapter(int id)
        {
            var model = this.chapterService.CurrentChapter<UpdateChapterViewModel>(id);
            return this.View(model);
        }

        [Authorize]
        public IActionResult GetChapters(int idStory)
        {
            var model = this.mapper.Map<CollectionOfChapters>(this.stories.CurrentStory<CollectionOfChapters>(idStory));
            return this.View(model);
        }

        public IActionResult AddChapter(int idStory)
        {
            CreateChapterInputModel model = new CreateChapterInputModel
            {
                StoryId = idStory,
            };
            return this.View(model);
        }

    }
}

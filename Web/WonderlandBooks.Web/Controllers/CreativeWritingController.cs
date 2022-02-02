namespace WonderlandBooks.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Data.ControllerDataService;
    using WonderlandBooks.Services.Data.ControllerDataService.Models;
    using WonderlandBooks.Services.Data.InputDataServices;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;
    using WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList;

    public class CreativeWritingController : BaseController
    {
        private readonly IGenreInputModelListItems genreInputModel;
        private readonly IEditionLanguageInputModelListItems editionLanguageInputModel;
        private readonly IMapper mapper;
        private readonly IStoryService storyService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IGetStoriesService stories;
        private readonly IChapterService chapterService;

        public CreativeWritingController(
            IGenreInputModelListItems genreInputModel,
            IEditionLanguageInputModelListItems editionLanguageInputModel,
            IMapper mapper,
            IStoryService storyService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment hostEnvironment,
            IGetStoriesService getStories,
            IChapterService chapterService)
        {
            this.genreInputModel = genreInputModel;
            this.editionLanguageInputModel = editionLanguageInputModel;
            this.mapper = mapper;
            this.storyService = storyService;
            this.userManager = userManager;
            this.hostEnvironment = hostEnvironment;
            this.stories = getStories;
            this.chapterService = chapterService;
        }

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

            return this.Redirect("AllStories");
        }

        public IActionResult CreateChapter(int id) // id story
        {
            CreateChapterInputModel model = new CreateChapterInputModel();
            model.StoryId = id;
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateChapter(CreateChapterInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.chapterService.CreateAsync(input);

            return this.RedirectToAction("AllStories");
        }

        [Authorize]
        public async Task<IActionResult> AllStories()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.mapper.Map<CollectionOfStories>(this.stories.All(user.Id));
            return this.View(model); // current story виж педал
        }

        public IActionResult CurrentStory(int id)
        {
            var model = this.mapper.Map<StoryViewModel>(this.stories.CurrentStory<StoryViewModel>(id));
            return this.View(model);
        }

        public async Task<IActionResult> DeleteStory(int id)
        {
            await this.storyService.DeleteAsync(id);
            return this.RedirectToAction("AllStories");
        }
    }
}

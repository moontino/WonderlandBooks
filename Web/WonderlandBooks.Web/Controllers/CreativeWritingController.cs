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
    using WonderlandBooks.Services.Data.InputDataServices;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;
    using WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList;

    public class CreativeWritingController : BaseController
    {
        private readonly IGenreInputModelListItems genreInputModel;
        private readonly IEditionLanguageInputModelListItems editionLanguageInputModel;
        private readonly IMapper mapper;
        private readonly ICreateStoryService storyService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment hostEnvironment;

        public CreativeWritingController(
            IGenreInputModelListItems genreInputModel,
            IEditionLanguageInputModelListItems editionLanguageInputModel,
            IMapper mapper,
            ICreateStoryService storyService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment hostEnvironment)
        {
            this.genreInputModel = genreInputModel;
            this.editionLanguageInputModel = editionLanguageInputModel;
            this.mapper = mapper;
            this.storyService = storyService;
            this.userManager = userManager;
            this.hostEnvironment = hostEnvironment;
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

            return this.Redirect("CreateChapter");
        }

        public IActionResult CreateChapter() // id story
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateChapter(CreateChapterInputModel input) // id story
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            return this.Redirect("CreateChapter");
        }

        public IActionResult AllStoriesByUser() // id user
        {
            // var tempId = "04cb4e0f-63ee-48de-a8db-aca8291fa79b";

            // var model = this.mapper.Map<AllStoriesViewModel>(this.allStories.All(tempId));
            return this.View();
        }
    }
}

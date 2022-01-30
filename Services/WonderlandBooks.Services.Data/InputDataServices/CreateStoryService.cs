namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Hosting;
    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public class CreateStoryService : ICreateStoryService
    {
        private readonly IRepository<CreativeWriting> writing;

        public CreateStoryService(IRepository<CreativeWriting> writing)
        {
            this.writing = writing;
        }

        public async Task CreateAsync(CreateStoryInputModel input, string imagePath)
        { // tags, characters 

            Directory.CreateDirectory($"{imagePath}/images/stories/");

            var personaLibrary = new CreativeWriting();
            personaLibrary.UserId = input.UserId;

            var story = new Story()
            {
                Title = input.Title,
                Description = input.Description,
                EditionLanguageId = input.EditionLanguageId,
                GenreId = input.GenreId,
            };

            var extension = Path.GetExtension(input.Image.FileName);
            var image = new Image()
            {
                Extension = extension,
            };


            var physicalPath = $"{imagePath}/images/stories/{image.Id}{extension}";
            story.Image = image;
            personaLibrary.Stories.Add(story);

            using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
            {
                await input.Image.CopyToAsync(fileStream);
            }

            await this.writing.AddAsync(personaLibrary);
            await this.writing.SaveChangesAsync();
        }
    }
}

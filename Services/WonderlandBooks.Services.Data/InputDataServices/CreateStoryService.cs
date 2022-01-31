namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public class CreateStoryService : ICreateStoryService
    {
        private readonly IRepository<CreativeWriting> writing;
        private readonly IDeletableEntityRepository<Story> stories;

        public CreateStoryService(IRepository<CreativeWriting> writing,
            IDeletableEntityRepository<Story> stories)
        {
            this.writing = writing;
            this.stories = stories;
        }

        public async Task CreateAsync(CreateStoryInputModel input, string imagePath)
        { // tags, characters 

            Directory.CreateDirectory($"{imagePath}/images/stories/");

            var storiesList = this.writing.AllAsNoTracking().Where(x => x.UserId == input.UserId).FirstOrDefault();

            if (storiesList == null)
            {
                storiesList = new CreativeWriting();
                storiesList.UserId = input.UserId;
                await this.writing.AddAsync(storiesList);
            }

            var story = new Story()
            {
                CreativeWritingId = storiesList.Id,
                Title = input.Title,
                Description = input.Description,
                EditionLanguageId = input.EditionLanguageId,
                GenreId = input.GenreId,
            };

            var image = new Image();

            if (input.Image == null)
            {
                image.Url = "https://nnpbeta.wustl.edu/img/bookCovers/genericBookCover.jpg";
            }
            else
            {
                var extension = Path.GetExtension(input.Image.FileName);// ще гърми ако няма снимка 
                image.Extension = extension;
                var physicalPath = $"{imagePath}/images/stories/{image.Id}{extension}";

                using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await input.Image.CopyToAsync(fileStream);
                }
            }

            story.Image = image;

            await this.stories.AddAsync(story);
            await this.writing.SaveChangesAsync();
        }
    }
}

namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public class StoryService : IStoryService
    {
        private readonly IRepository<CreativeWriting> writing;
        private readonly IDeletableEntityRepository<Story> stories;
        private readonly IDeletableEntityRepository<Image> images;

        public StoryService(
            IRepository<CreativeWriting> writing,
            IDeletableEntityRepository<Story> stories,
            IDeletableEntityRepository<Image> images)
        {
            this.writing = writing;
            this.stories = stories;
            this.images = images;
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
                var extension = Path.GetExtension(input.Image.FileName); // ще гърми ако няма снимка
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

        public async Task DeleteAsync(int id)
        {
            var currentStory = this.stories.All().FirstOrDefault(x => x.Id == id);
            currentStory.IsDeleted = true;
            await this.stories.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateStoryViewModel input, string imagelocal, string imagePath)
        {
            var writingId = this.stories.AllAsNoTracking().FirstOrDefault(x => x.Id == input.Id).CreativeWritingId;

            var story = new Story()
            {
                Id = input.Id,
                Title = input.Title,
                Description = input.Description,
                EditionLanguageId = input.EditionLanguageId,
                GenreId = input.GenreId,
                CreativeWritingId = writingId,
            };

            Image image;

            if (input.NewImage != null)
            {
                image = new Image();

                var extension = Path.GetExtension(input.NewImage.FileName);
                image.Extension = extension;
                var physicalPath = $"{imagePath}/images/stories/{image.Id}{extension}";

                using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await input.NewImage.CopyToAsync(fileStream);
                }
            }
            else
            {
                var temp = imagelocal.Replace("/images/stories/", string.Empty).Split('.').Take(1);

                var imageId = string.Join(string.Empty, temp);
                image = this.images.AllAsNoTracking().FirstOrDefault(x => x.Id == imageId);
            }

            story.Image = image;

            this.stories.Update(story);

            await this.stories.SaveChangesAsync();
        }
    }
}

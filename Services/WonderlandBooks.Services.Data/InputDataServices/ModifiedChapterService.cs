namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public class ModifiedChapterService : IModifiedChapterService
    {
        private readonly IDeletableEntityRepository<Chapter> chaptersRepository;
        private readonly IDeletableEntityRepository<Story> storyRepository;

        public ModifiedChapterService(IDeletableEntityRepository<Chapter> chaptersRepository, IDeletableEntityRepository<Story> storyRepository)
        {
            this.chaptersRepository = chaptersRepository;
            this.storyRepository = storyRepository;
        }

        public async Task CreateAsync(CreateChapterInputModel input)
        {
            var chapher = new Chapter()
            {
                Title = input.Title,
                Description = input.Description,
                StoryId = input.StoryId,
            };

            await this.chaptersRepository.AddAsync(chapher);
            await this.chaptersRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateChapterViewModel input)
        {
            var curChapter = this.chaptersRepository.All()
                 .FirstOrDefault(x => x.Id == input.Id);

            var model = new Chapter()
            {
                Title = input.Name,
                Description = input.Description,
                StoryId = curChapter.StoryId,
            };

            await this.chaptersRepository.AddAsync(model);

            await this.chaptersRepository.SaveChangesAsync();
        }
    }
}

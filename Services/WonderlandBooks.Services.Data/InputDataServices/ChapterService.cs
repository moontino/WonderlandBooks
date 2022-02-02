namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public class ChapterService : IChapterService
    {
        private readonly IDeletableEntityRepository<Chapter> chaptersRepository;

        public ChapterService(IDeletableEntityRepository<Chapter> chaptersRepository)
        {
            this.chaptersRepository = chaptersRepository;
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
    }
}

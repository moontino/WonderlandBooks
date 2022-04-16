namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public class ModifiedChapterService : IModifiedChapterService
    {
        private readonly IDeletableEntityRepository<Chapter> chaptersRepository;

        public ModifiedChapterService(IDeletableEntityRepository<Chapter> chaptersRepository)
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

        public async Task UpdateAsync(UpdateChapterViewModel input)
        {
            var chapter = this.chaptersRepository.All()
                 .FirstOrDefault(x => x.Id == input.Id);
            chapter.Description = input.Description;
            chapter.Title = input.Title;

            this.chaptersRepository.Update(chapter);
            await this.chaptersRepository.SaveChangesAsync();
        }
    }
}

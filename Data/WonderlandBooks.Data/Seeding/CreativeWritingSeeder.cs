namespace WonderlandBooks.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Models;

    public class CreativeWritingSeeder : ISeeder
    {
        public async Task SeedAsync(WonderlandDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CreativeWritings.Any())
            {
                return;
            }

            var writer = new CreativeWriting
            {
                UserId = "07f859a7-91d1-45d5-b145-ad14887971d9",
            };
            var story = new Story
            {
                Name = "Hero",
                Description = "When he awoke from his long sleep, he didn't know much more than his name.",
            };

            var genre = new Genre { Name = "Hero" };
            story.Genres.Add(genre);

            var tag = new Tag { Name = "history" };
            story.Tags.Add(tag);

            var chapterOne = new Chapter { Name = "First day", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc risus massa, sagittis sit amet sapien at, euismod semper urna. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nunc lectus diam, ultricies ut semper id, tincidunt a velit. Proin sed accumsan ipsum. Aenean dolor mauris, sollicitudin et metus eu, convallis ullamcorper eros. Vivamus consectetur nunc a pharetra luctus. Suspendisse aliquet justo in augue luctus mattis. Quisque justo nulla, luctus vitae enim ac, ultrices maximus dolor. Nam nec est purus. Ut tincidunt urna ac nulla placerat vulputate. Aliquam turpis sapien, posuere in fermentum eu, faucibus in quam. Aliquam congue justo id est egestas, quis egestas nisl tincidunt. Mauris tincidunt metus arcu, elementum consequat tellus pharetra vitae. In dictum, nisl et iaculis fermentum, quam nisl convallis quam, nec dictum tellus sapien nec lectus. Sed eget odio ac odio pretium porttitor." };

            var chapterTwo = new Chapter { Name = "Second day", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc risus massa, sagittis sit amet sapien at, euismod semper urna. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nunc lectus diam, ultricies ut semper id, tincidunt a velit. Proin sed accumsan ipsum. " };
            story.Chapters.Add(chapterOne);
            story.Chapters.Add(chapterTwo);

            writer.Stories.Add(story);

            var writerSecond = new CreativeWriting
            {
                UserId = "c9bf5aec-47bf-4663-b5ad-3ac3f436dc01",
            };
            var storySecond = new Story
            {
                Name = "Vampire",
                Description = "Seventeen-year-old Max Shopht has spent the last ten years fighting for survival in the notorious death prison",
            };

            var genreSecond = new Genre { Name = "Warrior" };
            storySecond.Genres.Add(genreSecond);

            var tagSecond = new Tag { Name = "magic" };
            storySecond.Tags.Add(tagSecond);

            var chapterOneSecondWriter = new Chapter { Name = "Dark day", Description = "Morbi pellentesque ex ut hendrerit euismod. Aliquam volutpat ornare congue. Integer gravida consequat tellus et pretium. Curabitur turpis arcu, blandit ac arcu ac, lobortis sodales tortor. Donec justo lorem, posuere non dictum nec, interdum quis odio. Donec a dictum neque. Integer iaculis tellus et lacus convallis rhoncus. Vivamus non turpis dui. Praesent et dolor rhoncus, gravida elit eget, posuere lectus. Donec vulputate, tellus a vestibulum faucibus, orci felis condimentum massa, ac mollis neque sem nec ex. Cras nec lobortis enim. Etiam vel gravida ipsum, ac mattis nunc." };

            storySecond.Chapters.Add(chapterOneSecondWriter);
            writerSecond.Stories.Add(storySecond);

            dbContext.CreativeWritings.Add(writer);
            dbContext.CreativeWritings.Add(writerSecond);

            await dbContext.SaveChangesAsync();
        }
    }
}

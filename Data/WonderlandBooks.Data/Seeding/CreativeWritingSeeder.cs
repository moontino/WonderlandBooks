namespace WonderlandBooks.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Models;

    public class CreativeWritingSeeder //: ISeeder
    {
        public async Task SeedAsync(WonderlandDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CreativeWritings.Any())
            {
                return;
            }

            var writer = new CreativeWriting
            {
                UserId = "a98c9680-1af9-4232-a01f-747be5ef2b4d",
            };
            var story = new Story
            {
                Title = "Имало едно време...",
                Description = "История за един човек",
            };
            story.Image = new Image { Url = "https://bigbag.bg/userfiles/productlargeimages/product_6124.jpg" };

            story.Genre = new Genre { Name = "Fairy tale" };

            story.EditionLanguage = new EditionLanguage { Name = "Bulgarian" };

            var tag = new Tag { Name = "history" };
            story.Tags.Add(tag);

            var characters = new Character { Name = "Иван" };
            story.Characters.Add(characters);

            var chapterOne = new Chapter { Title = "Първи ден", Description = "Имало едно време едно Имало едно време. То било доста самотно и много му се искало да се настани в началото на каква да е приказка. Обаче приказки рядко се срещали, тъй като човекът още не се бил очовечил. Разхождало се тъжно насам — натам това Имало едно време, отърквало се о някоя маймуна с надежда да й влезе в устата и да издърпа оттам нещо, което поне малко да прилича на приказка, но маймуните явно или нямали приказки, или не си ги давали. След като безкрайно дълго обикаляло и никъде не могло да открие приказка, измореното Имало едно време легнало и заспало." };
            var chapterTwo = new Chapter { Title = "На следващия ден", Description = "Имало едно време много се зарадва, засмя се и сълзите му станаха на бисери. Аз ги прибрах за всеки случай. И, както обещах, подхванах приказката. Може малко да съм я изкривил, защото, докато я пишех, щастливото Имало едно време непрекъснато си мушеше муцунката в мен. Но иначе стана съвсем добре, а, какво ще кажете?! И, разбира се, завършва така: седи си тук и си клати краката най-важното, най-хубавото, чудесното Имало едно време!" };

            story.Chapters.Add(chapterOne);
            story.Chapters.Add(chapterTwo);

            writer.Stories.Add(story);

            var writerSecond = new CreativeWriting
            {
                UserId = "7e257fc3-84f5-417f-af2a-6098124c7e6f",
            };
            var storySecond = new Story
            {
                Title = "Vampire",
                Description = "Seventeen-year-old Max Shopht has spent the last ten years fighting for survival in the notorious death prison",
            };

            storySecond.Image = new Image { Url = "https://pbs.twimg.com/media/DdgUzugX4AAX9Q-.jpg" };

            storySecond.Genre = new Genre { Name = "Warrior" };

            storySecond.EditionLanguage = new EditionLanguage { Name = "English" };

            var tagSecond = new Tag { Name = "magic" };
            storySecond.Tags.Add(tagSecond);

            var charactersSeconf = new Character { Name = "Max Shopht" };
            storySecond.Characters.Add(charactersSeconf);

            var chapterOneSecondWriter = new Chapter { Title = "Dark day", Description = "Morbi pellentesque ex ut hendrerit euismod. Aliquam volutpat ornare congue. Integer gravida consequat tellus et pretium. Curabitur turpis arcu, blandit ac arcu ac, lobortis sodales tortor. Donec justo lorem, posuere non dictum nec, interdum quis odio. Donec a dictum neque. Integer iaculis tellus et lacus convallis rhoncus. Vivamus non turpis dui. Praesent et dolor rhoncus, gravida elit eget, posuere lectus. Donec vulputate, tellus a vestibulum faucibus, orci felis condimentum massa, ac mollis neque sem nec ex. Cras nec lobortis enim. Etiam vel gravida ipsum, ac mattis nunc." };

            storySecond.Chapters.Add(chapterOneSecondWriter);

            writerSecond.Stories.Add(storySecond);

            dbContext.CreativeWritings.Add(writer);
            dbContext.CreativeWritings.Add(writerSecond);

            await dbContext.SaveChangesAsync();
        }
    }
}

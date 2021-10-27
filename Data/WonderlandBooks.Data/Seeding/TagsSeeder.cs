namespace WonderlandBooks.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Models;

    public class TagsSeeder : ISeeder
    {
        public async Task SeedAsync(WonderlandDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tags.Any())
            {
                return;
            }

            await dbContext.Tags.AddAsync(new Tag { Name = "werewolf" });
            await dbContext.Tags.AddAsync(new Tag { Name = "art" });
            await dbContext.Tags.AddAsync(new Tag { Name = "self-help" });
            await dbContext.Tags.AddAsync(new Tag { Name = "romance" });
            await dbContext.Tags.AddAsync(new Tag { Name = "hate" });

            await dbContext.SaveChangesAsync();
        }
    }
}

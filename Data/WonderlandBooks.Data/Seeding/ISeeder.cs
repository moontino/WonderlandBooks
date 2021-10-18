namespace WonderlandBooks.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(WonderlandDbContext dbContext, IServiceProvider serviceProvider);
    }
}

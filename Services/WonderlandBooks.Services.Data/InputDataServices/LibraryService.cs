namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class LibraryService : ILibraryService
    {
        private readonly IDeletableEntityRepository<Shelf> shelves;
        private readonly IDeletableEntityRepository<ApplicationUser> users;

        public LibraryService(IDeletableEntityRepository<Shelf> shelves, IDeletableEntityRepository<ApplicationUser> users)
        {
            this.shelves = shelves;
            this.users = users;
        }

        public async Task SaveAsync(string userId, int bookId)
        {
            var shelf = this.users.AllAsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => x.Shelves.FirstOrDefault(x => x.BookId == bookId))
                .FirstOrDefault();

            if (shelf != null)
            {
                return;
            }

            shelf = new Shelf()
            {
                BookId = bookId,
                UserId = userId,
            };

            await this.shelves.AddAsync(shelf);
            await this.shelves.SaveChangesAsync();
        }
    }
}

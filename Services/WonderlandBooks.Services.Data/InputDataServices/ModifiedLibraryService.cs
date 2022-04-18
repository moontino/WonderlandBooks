namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Linq;
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class ModifiedLibraryService : IModifiedLibraryService
    {
        private readonly IDeletableEntityRepository<Shelf> shelves;
        private readonly IDeletableEntityRepository<ApplicationUser> users;

        public ModifiedLibraryService(IDeletableEntityRepository<Shelf> shelves, IDeletableEntityRepository<ApplicationUser> users)
        {
            this.shelves = shelves;
            this.users = users;
        }

        public async Task ChangeType(string userId, int bookId, int value)
        {
            var shelf = this.shelves.All()
                .Where(x => x.UserId == userId && x.BookId == bookId)
                .FirstOrDefault();

            ReadType enumType = (ReadType)value;
            shelf.ReadType = enumType;

            await this.shelves.SaveChangesAsync();
        }

        public async Task RemoveBook(string userId, int bookId)
        {
            var shelf = this.shelves.All()
                 .Where(x => x.UserId == userId && x.BookId == bookId)
                 .FirstOrDefault();

            this.shelves.Delete(shelf);

            await this.shelves.SaveChangesAsync();
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
                ReadType = ReadType.WantToRead,
            };

            await this.shelves.AddAsync(shelf);
            await this.shelves.SaveChangesAsync();
        }
    }
}

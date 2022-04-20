namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class LibraryService : ILibraryService
    {
        private readonly IDeletableEntityRepository<Shelf> libraryRepository;

        public LibraryService(IDeletableEntityRepository<Shelf> libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        public bool IsBookInUserLibrary(int bookId, string userId)
        {
           return this.libraryRepository.All()
                .Where(x => x.UserId == userId)
                .Any(x => x.BookId == bookId);
        }

        public void Test(int bookId, string userId)
        {
            var test = this.libraryRepository.All().Take(1);
        }
    }
}

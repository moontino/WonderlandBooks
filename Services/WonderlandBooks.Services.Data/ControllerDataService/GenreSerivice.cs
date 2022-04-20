namespace WonderlandBooks.Services.Data.ControllerDataService
{
    using System.Collections.Generic;
    using System.Linq;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Services.Mapping;

    public class GenreSerivice : IGenreSerivice
    {
        private readonly IRepository<Genre> genreRepository;

        public GenreSerivice(IRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public T PostByName<T>(int id)
        {
            return this.genreRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public IEnumerable<T> TopGenres<T>()
        {
            return this.genreRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Books.Count())
                .Take(20)
                .To<T>()
                .ToList();
        }
    }
}

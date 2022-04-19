using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderlandBooks.Data.Common.Repositories;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public class PostSerivice : IPostSerivice
    {
        private readonly IRepository<Genre> genreRepository;

        public PostSerivice(IRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public T PostById<T>(int id)
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

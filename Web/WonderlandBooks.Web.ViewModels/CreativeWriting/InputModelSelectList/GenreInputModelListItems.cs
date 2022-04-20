namespace WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class GenreInputModelListItems : IGenreInputModelListItems
    {
        private readonly IRepository<Genre> repositoryGenres;

        public GenreInputModelListItems(IRepository<Genre> repositoryGenres)
        {
            this.repositoryGenres = repositoryGenres;
            this.OnGet();
        }

        public List<SelectListItem> Options { get; set; }

        public void OnGet()
        {
            this.Options = this.repositoryGenres.AllAsNoTracking()
                 .OrderByDescending(x => x.Books.Count())
                 .Take(20)
                 .Select(x => new SelectListItem
                 {
                     Value = x.Id.ToString(),
                     Text = x.Name,
                 }).ToList();
        }
    }
}

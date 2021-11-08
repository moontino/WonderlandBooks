namespace WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class EditionLanguageInputModelListItems : IEditionLanguageInputModelListItems
    {
        private readonly IRepository<EditionLanguage> repositoryLanguage;

        public EditionLanguageInputModelListItems(IRepository<EditionLanguage> repositoryLanguage)
        {
            this.repositoryLanguage = repositoryLanguage;
            this.OnGet();
        }

        public List<SelectListItem> Options { get;  set; }

        public void OnGet()
        {
            this.Options = this.repositoryLanguage.AllAsNoTracking()
                 .OrderByDescending(x => x.Books.Count())
                 .Take(10)
                 .Select(x => new SelectListItem
                 {
                     Value = x.Id.ToString(),
                     Text = x.Name,
                 }).ToList();
        }
    }
}

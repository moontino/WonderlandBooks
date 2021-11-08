namespace WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IGenreInputModelListItems
    {
        List<SelectListItem> Options { get; }

        void OnGet();
    }
}

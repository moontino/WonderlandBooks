namespace WonderlandBooks.Web.ViewModels.CreativeWriting.InputModelSelectList
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IEditionLanguageInputModelListItems
    {
        List<SelectListItem> Options { get; set; }

        void OnGet();
    }
}

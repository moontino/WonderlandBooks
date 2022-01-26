namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    using System.Collections.Generic;

    public class AllStoriesViewModel
    {
        public string UserId { get; set; }

        public ICollection<ListOfStoriesViewModel> Stories { get; set; }
    }
}

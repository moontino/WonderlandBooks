using System.Collections.Generic;

namespace WonderlandBooks.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public CountViewModel Count { get; set; }

        public IEnumerable<HomeBooksViewModel> RandomBooks { get; set; }
    }
}

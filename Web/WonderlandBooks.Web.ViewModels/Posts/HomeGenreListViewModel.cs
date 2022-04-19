using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.Posts
{
    public class HomeGenreListViewModel
    {
        public IEnumerable<HomeGenreViewModel> Genres { get; set; }
    }
}

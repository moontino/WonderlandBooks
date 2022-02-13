using System;
using System.Collections.Generic;
using System.Text;

namespace WonderlandBooks.Web.ViewModels.CreativeWriting
{
    public abstract class BaseStoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}

﻿namespace WonderlandBooks.Web.ViewModels.Books
{
    using System.Collections.Generic;

    public class BookRecommendationsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public IList<BookRecommendationsAuthorsViewModel> Authors { get; set; }
    }
}

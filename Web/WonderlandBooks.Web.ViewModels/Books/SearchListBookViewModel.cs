﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WonderlandBooks.Web.ViewModels.Books
{
    public class SearchListBookViewModel
    {
        public IEnumerable<SearchBooksViewModel> Books { get; set; }
    }
}
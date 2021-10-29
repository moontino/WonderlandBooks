﻿namespace WonderlandBooks.Services.Data.ControllerServiceData.Models
{
    using System.Collections.Generic;

    public class AuthorSeriesDto
    {
        public string SeriesName { get; set; }

        public IList<AuthorSeriesBooksDto> Books { get; set; }
    }
}

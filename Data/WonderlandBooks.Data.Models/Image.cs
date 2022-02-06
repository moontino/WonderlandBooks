namespace WonderlandBooks.Data.Models
{
    using System;
    using WonderlandBooks.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Url { get; set; }

        public string RemoteImageUrl { get; set; }

        public string Extension { get; set; }
    }
}

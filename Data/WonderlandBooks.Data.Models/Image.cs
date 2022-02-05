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

        public Story Story { get; set; }

        public int StoryId { get; set; }

        public string Url { get; set; }

        public string RemoteImageUrl { get; set; }

        public string Extension { get; set; }
    }
}

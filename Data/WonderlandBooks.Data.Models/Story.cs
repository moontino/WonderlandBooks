namespace WonderlandBooks.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using WonderlandBooks.Data.Common.Models;

    public class Story : BaseDeletableModel<int>
    {
        public Story()
        {
            this.Chapters = new HashSet<Chapter>();
            this.Tags = new HashSet<Tag>();
            this.Genres = new HashSet<Genre>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}

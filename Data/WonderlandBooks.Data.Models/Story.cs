namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Story : BaseDeletableModel<int>
    {
        public Story()
        {
            this.Chapters = new HashSet<Chapter>();
            this.Tags = new HashSet<Tag>();
            this.Characters = new HashSet<Character>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int EditionLanguageId { get; set; }

        public EditionLanguage EditionLanguage { get; set; }

        public int CreativeWritingId { get; set; }

        public CreativeWriting CreativeWriting { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}

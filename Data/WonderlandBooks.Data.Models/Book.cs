namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;

    using WonderlandBooks.Data.Common.Models;

    public class Book : BaseModel<int>
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
            this.Genres = new HashSet<Genre>();
            this.Characters = new HashSet<Character>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }

        public string DownloadBookExtension { get; set; } // TODO: lib for pdf

        public int NumberOfSet { get; set; }

        public int BookSeriesId { get; set; }

        public BookSeries BookSeries { get; set; }

        public string ImageId { get; set; }

        public Image Image { get; set; }

        public int EditionLanguageId { get; set; }

        public EditionLanguage EditionLanguage { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        // TODO: Rating add
    }
}

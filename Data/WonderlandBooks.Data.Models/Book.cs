namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Book : BaseModel<int>
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Comments = new HashSet<Comment>();
            this.Genres = new HashSet<Genre>();
            this.Characters = new HashSet<Character>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? Pages { get; set; }

        [Required]
        public string BookUrl { get; set; }

        public string ImageId { get; set; }

        public Image Image { get; set; }

        public int EditionLanguageId { get; set; }

        public EditionLanguage EditionLanguage { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<Shelf> Shelves { get; set; }

        // TODO: Rating add
    }
}

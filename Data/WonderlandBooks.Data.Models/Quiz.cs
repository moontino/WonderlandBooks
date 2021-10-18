namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using WonderlandBooks.Data.Common.Models;

    public class Quiz : BaseDeletableModel<int>
    {
        public Quiz()
        {
            this.Questions = new HashSet<Question>();
        }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}

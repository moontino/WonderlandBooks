namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using WonderlandBooks.Data.Common.Models;

    public class Chapter : BaseDeletableModel<int>
    {
        public Chapter()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Name { get; set; }

        public int CharactersCount { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

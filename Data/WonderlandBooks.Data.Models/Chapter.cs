namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Chapter : BaseDeletableModel<int>
    {
        public Chapter()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int CharactersCount { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

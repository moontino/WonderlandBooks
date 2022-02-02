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

        public Story Story { get; set; }

        public int StoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

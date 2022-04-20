namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<VotePost>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<VotePost> Votes { get; set; }
    }
}

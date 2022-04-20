namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class CreativeWriting : BaseDeletableModel<int>
    {
        public CreativeWriting()
        {
            this.Stories = new HashSet<Story>();
        }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}

﻿namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;

    using WonderlandBooks.Data.Common.Models;

    public class Discussion : BaseDeletableModel<int>
    {
        public Discussion()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

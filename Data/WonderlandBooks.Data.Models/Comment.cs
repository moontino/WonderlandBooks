namespace WonderlandBooks.Data.Models
{
    using WonderlandBooks.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        // TODO: check this
        public string Content { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // TODO: maybe rating add
    }
}

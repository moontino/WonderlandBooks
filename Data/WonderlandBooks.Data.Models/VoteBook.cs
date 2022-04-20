using System.ComponentModel.DataAnnotations;
using WonderlandBooks.Data.Common.Models;

namespace WonderlandBooks.Data.Models
{
    public class VoteBook : BaseModel<int>
    {
        public Book Book { get; set; }

        public int BookId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public byte Value { get; set; }
    }
}

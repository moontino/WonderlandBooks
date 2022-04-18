using System.ComponentModel.DataAnnotations;

namespace WonderlandBooks.Web.ViewModels.VoteBooks
{
    public class PostVoteInputModel
    {
        public int BookId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}

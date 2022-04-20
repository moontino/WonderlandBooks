using System.ComponentModel.DataAnnotations;

namespace WonderlandBooks.Web.ViewModels.VoteBooks
{
    public class BookVoteInputModel
    {
        public int BookId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}

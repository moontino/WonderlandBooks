namespace WonderlandBooks.Data.Models
{
    using WonderlandBooks.Data.Common.Models;

    public class Shelf : BaseDeletableModel<int>
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public ReadType ReadType { get; set; }
    }
}

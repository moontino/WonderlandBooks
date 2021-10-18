namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;

    using WonderlandBooks.Data.Common.Models;

    public class EditionLanguage : BaseModel<int>
    {
        public EditionLanguage()
        {
            this.Books = new HashSet<Book>();
        }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Character : BaseModel<int>
    {
        public Character()
        {
            this.Books = new HashSet<Book>();
        }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

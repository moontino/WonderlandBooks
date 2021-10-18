namespace WonderlandBooks.Data.Models
{
    using WonderlandBooks.Data.Common.Models;

    public class Character : BaseModel<int>
    {
        public string Name { get; set; }
    }
}

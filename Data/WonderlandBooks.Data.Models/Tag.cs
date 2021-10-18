namespace WonderlandBooks.Data.Models
{
    using WonderlandBooks.Data.Common.Models;

    public class Tag : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}

namespace WonderlandBooks.Data.Models
{
    using WonderlandBooks.Data.Common.Models;

    public class Answer : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}

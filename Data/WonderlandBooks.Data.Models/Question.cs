namespace WonderlandBooks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WonderlandBooks.Data.Common.Models;

    public class Question : BaseDeletableModel<int>
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public int CorrectIndexOfQuestion { get; set; }
    }
}

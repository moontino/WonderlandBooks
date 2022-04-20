using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderlandBooks.Data.Common.Models;

namespace WonderlandBooks.Data.Models
{
    public class VotePost:BaseModel<int>
    {

        public Post Post { get; set; }

        public int PostId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public VoteType Type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderlandBooks.Web.ViewModels.Comments
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }

        public int PostId { get; set; }
    }
}

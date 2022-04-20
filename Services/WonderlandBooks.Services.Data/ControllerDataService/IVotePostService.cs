using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderlandBooks.Services.Data.ControllerDataService
{
    public interface IVotePostService
    {
        Task SetVoteAsync(int postId, string userId, bool isUpVote);

        int GetVotes(int postId);
    }
}

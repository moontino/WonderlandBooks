using System.Collections.Generic;

namespace WonderlandBooks.Web.ViewModels.Recommendations
{
    public class RecommendationsListViewModel
    {
        public RecommendationsListViewModel()
        {
            this.Models = new List<RecommendationsViewModel>();
        }

        public ICollection<RecommendationsViewModel> Models { get; set; }

    }
}

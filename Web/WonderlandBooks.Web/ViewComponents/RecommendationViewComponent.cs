namespace WonderlandBooks.Web.ViewComponents
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WonderlandBooks.Services.Data.ModelDataServices;
    using WonderlandBooks.Web.ViewModels.Recommendations;

    public class RecommendationViewComponent : ViewComponent
    {
        private readonly IBookRecommendationsService recommendationsService;
        private readonly IMapper mapper;

        public RecommendationViewComponent(
            IBookRecommendationsService recommendationsService,
            IMapper mapper)
        {
            this.recommendationsService = recommendationsService;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke(int id, int count)
        {
            ICollection<RecommendationsViewModel> model = new List<RecommendationsViewModel>();

            return this.View(model);
        }
    }
}

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

            for (int i = 0; i < count; i++)
            {
                var recommendation = this.mapper.Map<RecommendationsViewModel>(this.recommendationsService.Recommendation<RecommendationsViewModel>(id, count));

                if (model.Any(x => x.Id == recommendation.Id))
                {
                    count--;
                    continue;
                }

                model.Add(recommendation);
            }

            return this.View(model);
        }
    }
}

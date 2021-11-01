namespace WonderlandBooks.Web.MapperProfile
{
    using AutoMapper;
    using WonderlandBooks.Services.Data.ControllerDataService.Models;
    using WonderlandBooks.Web.ViewModels.Home;

    public class HomeProfile : Profile
    {
        public HomeProfile()
        {
            this.CreateMap<CountDto, CountViewModel>();
        }
    }
}

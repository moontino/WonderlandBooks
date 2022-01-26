namespace WonderlandBooks.Web.MapperProfile
{
    using AutoMapper;
    using WonderlandBooks.Services.Data.ControllerDataService.Models;
    using WonderlandBooks.Web.ViewModels.CreativeWriting;

    public class WritingProfile : Profile
    {
        public WritingProfile()
        {
            this.CreateMap<AllStoriesDto, AllStoriesViewModel>();
            this.CreateMap<ListOfStoriesDto, ListOfStoriesViewModel>();
        }
    }
}

namespace WonderlandBooks.Web.MapperProfile
{
    using AutoMapper;
    using WonderlandBooks.Services.Data.ControllerServiceData.Models;
    using WonderlandBooks.Web.ViewModels.Authors;

    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            this.CreateMap<AuthorBooksDto, AuthorBooksViewModel>();
            this.CreateMap<AuthorDto, AuthorViewModel>();
            this.CreateMap<AuthorSeriesBooksDto, AuthorSeriesBooksViewModel>();
            this.CreateMap<AuthorSeriesDto, AuthorSeriesViewModel>();
        }
    }
}

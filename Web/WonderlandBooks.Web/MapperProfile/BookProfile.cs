namespace WonderlandBooks.Web.MapperProfile
{
    using AutoMapper;
    using WonderlandBooks.Services.Data.ControllerServiceData.Models;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BookProfile : Profile
    {
        public BookProfile()
        {
            this.CreateMap<BookDto, BookViewModel>();
            this.CreateMap<BookAuthorDto, BookAuthorViewModel>();
            this.CreateMap<BookRecommendationsDto, BookRecommendationsViewModel>();
        }
    }
}

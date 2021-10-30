namespace WonderlandBooks.Web.MapperProfile
{
    using AutoMapper;
    using WonderlandBooks.Services.Data.ControllerDataService.Models;
    using WonderlandBooks.Web.ViewModels.Books;

    public class BookProfile : Profile
    {
        public BookProfile()
        {
            this.CreateMap<BookDto, BookViewModel>();
            this.CreateMap<BookAuthorDto, BookAuthorViewModel>();
            this.CreateMap<BookRecommendationsDto, BookRecommendationsViewModel>();
            this.CreateMap<BookRecommendationsAuthorsDto, BookRecommendationsAuthorsViewModel>();
            this.CreateMap<BookSeriesDto, BookSeriesViewModel>();
            this.CreateMap<BookSeriesBooksDto, BookSeriesBooksViewModel>();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WonderlandBooks.Data.Models;
using WonderlandBooks.Services.Mapping;

namespace WonderlandBooks.Web.ViewModels.Books
{
    public class SearchBooksViewModel : BasicBookViewModel, IMapFrom<Book>, IHaveCustomMappings
    {
        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, SearchBooksViewModel>().ForMember(
                x => x.Description,
                y => y.MapFrom(x => x.Description == null ? "..." : x.Description
                .Substring(0, x.Description.Length <= 500 ? x.Description.Length : 500)));
        }
    }
}

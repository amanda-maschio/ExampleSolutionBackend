using AutoMapper;
using HotelSolutionBackend.Query.Application.ViewModels;
using HotelSolutionBackend.Query.Model.Models;

namespace HotelSolutionBackend.Query.Application.Mapper
{
    public class QueryModelMapper : Profile
    {
        public QueryModelMapper()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}

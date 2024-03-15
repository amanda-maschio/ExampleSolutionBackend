using HotelSolutionBackend.Query.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Query.Application.Abstractions
{
    public interface IUserAppService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        UserViewModel GetById(int id);
    }
}

using AutoMapper;
using HotelSolutionBackend.Query.Application.Abstractions;
using HotelSolutionBackend.Query.Application.ViewModels;
using HotelSolutionBackend.Query.Model.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Query.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IQueryContext _queryContext;
        private readonly IMapper _mapper;

        public UserAppService(IQueryContext queryContext, IMapper mapper)
        {
            _queryContext = queryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var users = await _queryContext.AllUsers.ToListAsync();
            var usersViewModel = users.Select(r => _mapper.Map<UserViewModel>(r)).ToList();
            return usersViewModel;
        }

        public UserViewModel GetById(int id)
        {
            var user = _mapper.Map<UserViewModel>(_queryContext.AllUsers.Where(r => r.Id == id).First());
            return user;
        }
    }
}

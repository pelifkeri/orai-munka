using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Database.Interfaces;
using WebServer.Database.Models;
using WebServerEntityFramework.DTOs;
using WebServerEntityFramework.Interfaces;

namespace WebServerEntityFramework.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _repository.ListAllAsync();

            var result = _mapper.Map<List<UserDto>>(users);

            return result;
        }

        public async Task<UserDto> CreateNewUser(UserDto user)
        {
            var entity = _mapper.Map<User>(user);

            var result = await _repository.AddAsync(entity);

            var response = _mapper.Map<UserDto>(result);

            return response;
        }

        public async Task DeleteUser(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> UpdateUser(int id, UserDto user)
        {
            var entity = _mapper.Map<User>(user);

            var result = await _repository.UpdateAsync(entity, id);

            var response = _mapper.Map<UserDto>(result);

            return response;
        }
    }
}

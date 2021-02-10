using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Database;
using WebServer.Database.Models;
using WebServerEntityFramework.DTOs;
using WebServerEntityFramework.Exceptions;
using WebServerEntityFramework.Interfaces;

namespace WebServerEntityFramework.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            if (users.Count == 0)
            {
                throw new UserNotFoundException();
            }

            var result = _mapper.Map<List<UserDto>>(users);

            return result;
        }

        public async Task<UserDto> CreateNewUser(UserDto user)
        {
            var dbEntity = _mapper.Map<User>(user);

            var result = await _context.Users.AddAsync(dbEntity);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<UserDto>(result.Entity);

            return response;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserDto> UpdateUser(int id, UserDto user)
        {
            var entity = await _context.Users.FindAsync(id);

            if (entity == null)
            {
                throw new UserNotFoundException();
            }

            _context.Entry(entity).CurrentValues.SetValues(user);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.Id).IsModified = false;

            await _context.SaveChangesAsync();

            var response = _mapper.Map<UserDto>(entity);

            return response;
        }
    }
}

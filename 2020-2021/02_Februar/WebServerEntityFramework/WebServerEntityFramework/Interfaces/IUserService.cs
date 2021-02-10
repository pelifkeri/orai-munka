using System.Collections.Generic;
using System.Threading.Tasks;
using WebServerEntityFramework.DTOs;

namespace WebServerEntityFramework.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> CreateNewUser(UserDto user);
        Task DeleteUser(int id);
        Task<UserDto> UpdateUser(int id, UserDto user);
    }
}

using Coders_Airlines.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Coders_Airlines.Auth.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterDTO registerDto, ModelStateDictionary modelstate);
        public Task<UserDTO> Authenticate(string username, string password);
        public Task Logout();
    };
}
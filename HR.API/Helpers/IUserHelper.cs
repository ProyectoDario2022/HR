using HR.API.Data.Entities;
using HR.API.Models;
using HR.Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace HR.API.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);//le paso el email y me devuelve el usuario
        Task<User> GetUserAsync(Guid id);//le paso el email y me devuelve el usuario
        Task<IdentityResult> AddUserAsync(User user,string password);
        Task<User> AddUserAsync(AddUserViewModel model,Guid imageId ,UserType userType);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<IdentityResult> DeleteUserAsync(User user);
        Task CheckRoleAsync(string roleName);//crea los roles en la aplicacion
        Task AddUserToRoleAsync(User user,string roleName);//adiciona permisos al usuario
        Task<bool> IsUserInRoleAsync(User user,string roleName);//me indica si el usuario esta o no en el rol

        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }
}

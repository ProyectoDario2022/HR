using HR.API.Data;
using HR.API.Data.Entities;
using HR.API.Models;
using HR.Common.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,DataContext context,
             SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            var o= await _userManager.CreateAsync(user, password);

            return o;
        }

        public async Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType)
        {
            User user = new User
            {
                Direccion = model.Direccion,
                Document = model.Document,
                Email = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ImageId = imageId,
                PhoneNumber = model.PhoneNumber,
                Funcion = await _context.Funciones.FindAsync(model.FuncionId),
                UserName = model.Username,
                UserType = userType

            };
            IdentityResult result=await _userManager.CreateAsync(user, model.Password);
            if(result != IdentityResult.Success)
            {
                return null;
            }
            User newUser = await GetUserAsync(model.Username);
            await AddUserToRoleAsync(newUser, user.UserType.ToString());
            return newUser;

        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
           await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(x => x.Funcion)
                .Include(x => x.ReclamoTecnicos)
                .ThenInclude(x => x.Reclamo)
                .FirstOrDefaultAsync(x => x.Email == email);//aca iria include (x=>x.DocumentType) si tendria tipo de documento
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _context.Users
                .Include(x=>x.Funcion)
                .Include(x=>x.ReclamoTecnicos)
                .ThenInclude(x=>x.Reclamo)
                .FirstOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username, model.Password,model.RememberMe,false);
            //el false es para q no bloquee con muchos intentos de logueo fallado 
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            User currentUser = await GetUserAsync(user.Email);
            currentUser.LastName=user.LastName;
            currentUser.FirstName=user.FirstName;
            currentUser.Funcion = user.Funcion;
            currentUser.Document=user.Document;
            currentUser.Direccion=user.Direccion;
            currentUser.ImageId=user.ImageId;
            currentUser.PhoneNumber=user.PhoneNumber;
           
            return await _userManager.UpdateAsync(currentUser);
        }
    }
}

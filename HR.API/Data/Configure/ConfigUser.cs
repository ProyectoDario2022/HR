using HR.API.Data.Entities;
using HR.API.Helpers;
using HR.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.API.Data.Configure
{
    public class ConfigUser
    {
        private readonly IUserHelper _userHelper;
        public ConfigUser(EntityTypeBuilder<User> BuilderUser)
        {
            var user = new User
            {
                Direccion = "Entre rios 10",
                Document = "22890345",
                Email = "prueba1@gmail.com",
                FirstName = "Dario",
                LastName = "Paez",
                PhoneNumber = "11111111",
                UserName = "prueba1@gmail.com",
                UserType = UserType.Admin,

            };
            BuilderUser.HasData(user);
           // _userHelper.AddUserAsync(user, "123456");
          //  _userHelper.AddUserToRoleAsync(user, UserType.Admin.ToString());

            var user2 = new User
            {
                Direccion = "callao 1",
                Document = "22890456",
                Email = "prueba2@gmail.com",
                FirstName = "Eze",
                LastName = "Anchorena",
                PhoneNumber = "11111111",
                UserName = "prueba2@gmail.com",
                UserType = UserType.Admin,
            };
            BuilderUser.HasData(user2);
           // _userHelper.AddUserAsync(user2, "123456");
           // _userHelper.AddUserToRoleAsync(user2, UserType.Admin.ToString());

            var user3 = new User
            {
                Direccion = "callao 1",
                Document = "22890456",
                Email = "prueba3@gmail.com",
                FirstName = "Maximiliano",
                LastName = "Dominguez",
                PhoneNumber = "11111111",
                UserName = "prueba3@gmail.com",
                UserType = UserType.User,

            };
            BuilderUser.HasData(user3);
           // _userHelper.AddUserAsync(user3, "123456");
          //  _userHelper.AddUserToRoleAsync(user3, UserType.Admin.ToString());
        }
    }
}

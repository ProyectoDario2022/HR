using HR.API.Data.Entities;
using HR.API.Models;

namespace HR.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);
        UserViewModel ToUserViewModel(User user);

    }
}

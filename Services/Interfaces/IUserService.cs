using Shop_Manager_Assitant_Backend.Model;

namespace Shop_Manager_Assitant_Backend.Services.Interfaces
{
    public interface IUserService
    {
        IList<User> GetUsersByCity(int cityId);
    }
}

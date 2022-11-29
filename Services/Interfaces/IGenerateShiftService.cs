using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.ModelsDTO;

namespace Shop_Manager_Assitant_Backend.Services.Interfaces
{
    public interface IGenerateShiftService
    {
        ResponseDTO GenerateShift(int cityId);
        User GetRandomUser(IList<User> usersToModify);
    }
}

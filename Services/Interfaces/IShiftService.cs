using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.ModelsDTO;

namespace Shop_Manager_Assitant_Backend.Services.Interfaces
{
    public interface IShiftService
    {
        ResponseDTO Add(Shift shift);
    }
}

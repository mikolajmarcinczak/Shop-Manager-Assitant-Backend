using Shop_Manager_Assitant_Backend.ModelsDTO;

namespace Shop_Manager_Assitant_Backend.Services.Interfaces
{
    public interface IStatisticsService
    {
        BestShiftsDTO GetBestShifts(); 
        BestUsersDTO GetBestUsersByCity(int cityId);
    }
}

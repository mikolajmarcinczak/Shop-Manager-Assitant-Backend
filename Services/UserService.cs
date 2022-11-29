using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.Services.Interfaces;

namespace Shop_Manager_Assitant_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly ShiftAssistanceContext _context;

        public UserService(ShiftAssistanceContext context)
        {
            _context = context;
        }

        public IList<User> GetUsersByCity(int cityId)
        {
            return _context.Users.Where(u => u.CityId == cityId).ToList();
        }
    }
}

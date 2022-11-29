using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.ModelsDTO;
using Shop_Manager_Assitant_Backend.Services.Interfaces;

namespace Shop_Manager_Assitant_Backend.Services
{
    public class GenerateShiftService : IGenerateShiftService
    {
        private readonly IUserService _userService;
        private readonly IShiftService _shiftService;

        public GenerateShiftService(IUserService userService,
                                    IShiftService shiftService) {
            _userService = userService;
            _shiftService = shiftService;
        }

        Random generator;
        IList<User> users;
            
        public ResponseDTO GenerateShift(int cityId)
        {
            generator = new Random();
            users = _userService.GetUsersByCity(cityId);
            IList<User> usersToModify = users.ToList();

            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month == 12 ? -11 : +1);
            var counterDay = 1;
            var date = new DateTime(DateTime.Now.Month == 12 ? DateTime.Now.Year + 1 : DateTime.Now.Year, DateTime.Now.Month == 12 ? DateTime.Now.Month - 11 : DateTime.Now.Month + 1, 1);

            while (counterDay <= daysInMonth)
            {
                Shift shift1 = new Shift()
                {
                    ShiftNumber = 1,
                    Date = date,
                    CityId = cityId,
                    UserId = GetRandomUser(usersToModify).Id,
                    User2Id = GetRandomUser(usersToModify).Id,
                    User3Id = GetRandomUser(usersToModify).Id,
                    User4Id = GetRandomUser(usersToModify).Id
                };

                Shift shift2 = new Shift()
                {
                    ShiftNumber = 2,
                    Date = date,
                    CityId = cityId,
                    UserId = GetRandomUser(usersToModify).Id,
                    User2Id = GetRandomUser(usersToModify).Id,
                    User3Id = GetRandomUser(usersToModify).Id,
                    User4Id = GetRandomUser(usersToModify).Id
                };

                _shiftService.Add(shift1);
                _shiftService.Add(shift2);
                counterDay++;
                date = date.AddDays(1);
            }
            
            return new ResponseDTO() { Code = "200", Message="Generated report", Status = "Success" };
        }

        public User GetRandomUser(IList<User> usersToModify)
        {
            if (usersToModify.Count() > 0)
            {
                int i = generator.Next(0, usersToModify.Count());
                var user = usersToModify.ElementAt(i);
                usersToModify.RemoveAt(i);
                return user;
            }
            else
            {
                usersToModify = users.ToList();
                int i = generator.Next(0, usersToModify.Count());
                var user = usersToModify.ElementAt(i);
                usersToModify.RemoveAt(i);
                return user;
            }
        }
    }
}

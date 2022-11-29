using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.ModelsDTO;
using Shop_Manager_Assitant_Backend.Services.Interfaces;

namespace Shop_Manager_Assitant_Backend.Services
{
    public class ShiftService : IShiftService
    {
        private readonly ShiftAssistanceContext _context;

        public ShiftService(ShiftAssistanceContext context)
        {
            _context = context;
        }

        public ResponseDTO Add(Shift shift)
        {
            try
            {
                _context.Shifts.Add(shift);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return new ResponseDTO() { Code = "400", Message = e.Message, Status = "Failed" };
            }

            return new ResponseDTO() { Code= "200", Message = "Added shift to DB", Status = "Success" };
        }

        public ShiftsDTO ShowSchedule(int cityId)
        {
            ShiftsDTO shiftsDTO = new ShiftsDTO()
            {
                shiftsList = new List<Shift>()
            };
            var shifts = _context.Shifts.Where(s => s.CityId == cityId && s.Date.Value.Month == DateTime.Now.Month).ToArray();

            foreach (var item in shifts)
            {
                var shift = new Shift()
                {
                    AccountBalance = item.AccountBalance == null ? 1 : item.AccountBalance.Value,
                    CityId = item.CityId,
                    Id = item.Id,
                    Date = item.Date,
                    ShiftNumber = item.ShiftNumber,
                    UserId = item.UserId,
                    User2Id = item.User2Id,
                    User3Id = item.User3Id,
                    User4Id = item.User4Id
                };
                shiftsDTO.shiftsList.Add(shift);
            }
            return shiftsDTO;
        }
    }
}

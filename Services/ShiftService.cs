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
    }
}

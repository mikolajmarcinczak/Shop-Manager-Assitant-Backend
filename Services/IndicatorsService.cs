using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.Services.Interfaces;

namespace Shop_Manager_Assitant_Backend.Services
{
    public class IndicatorsService : IIndicatorsService
    {
        private readonly ShiftAssistanceContext _context;

        public IndicatorsService(ShiftAssistanceContext context)
        {
            _context = context;
        }

        public decimal GetDayValueByDayNumber(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1: return _context.DayValues.SingleOrDefault().Monday ?? 0.5m;
                case 2: return _context.DayValues.SingleOrDefault().Tuesday?? 0.5m;
                case 3: return _context.DayValues.SingleOrDefault().Wednesday ?? 0.5m;
                case 4: return _context.DayValues.SingleOrDefault().Thursday ?? 0.5m;
                case 5: return _context.DayValues.SingleOrDefault().Friday ?? 0.5m;
                case 6: return _context.DayValues.SingleOrDefault().Saturday ?? 0.5m;
                case 7: return _context.DayValues.SingleOrDefault().Sunday ?? 0.5m;
                default: return 0.5m;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.ModelsDTO;

namespace Shop_Manager_Assitant_Backend.Services
{
    public class StatisticsService
    {
        private readonly ShiftAssistanceContext _context;
        private readonly IndicatorsService _indicators;

        public StatisticsService(ShiftAssistanceContext context,
                                 IndicatorsService indicators)
        {
            _context = context;
            _indicators = indicators;
        }

        public BestShiftsDTO GetBestShifts()
        {
            var shifts = _context.Shifts.Where(s => s.Date.Value.Month == (DateTime.Now.Month == 1 ? DateTime.Now.Month + 11 : DateTime.Now.Month - 1))
                .Include(i => i.ShiftNumber)
                .Include(i => i.User)
                .Include(i => i.User2)
                .Include(i => i.User3)
                .Include(i => i.User4);

            Dictionary<int, decimal?> shiftsDict = new Dictionary<int, decimal?>();

            foreach (var shift in shifts)
            {
                var indicatorDay = _indicators.GetDayValueByDayNumber(shift.Date.Value.Day);
                var indicatorAB = (shift.AccountBalance == null ? 1 : shift.AccountBalance) * shift.ShiftNumberNavigation.ShiftValueVal * indicatorDay;
                shiftsDict.Add(shift.Id, indicatorAB);
            }

            shiftsDict.OrderByDescending(o => o.Value).ToList();

            BestShiftsDTO bestShiftsList = new BestShiftsDTO() { BestShifts = new List<BestShiftDTO>() };

            foreach (var item in shiftsDict)
            {
                var bestShift = new BestShiftDTO()
                {
                    ShiftId = item.Key,
                    Result = (int)item.Value
                };

                bestShiftsList.BestShifts.Add(bestShift);
            }

            return bestShiftsList;
        }
    }
}

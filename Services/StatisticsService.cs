using Microsoft.EntityFrameworkCore;
using Shop_Manager_Assitant_Backend.Model;
using Shop_Manager_Assitant_Backend.ModelsDTO;
using Shop_Manager_Assitant_Backend.Services.Interfaces;

namespace Shop_Manager_Assitant_Backend.Services
{
    public class StatisticsService : IStatisticsService
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

        public BestUsersDTO GetBestUsersByCity(int cityId)
        {
            var shifts = _context.Shifts.Where(s => s.Date.Value.Month == (DateTime.Now.Month == 1 ? DateTime.Now.Month + 11 : DateTime.Now.Month - 1))
                .Include(i => i.ShiftNumber)
                .Include(i => i.User)
                .Include(i => i.User2)
                .Include(i => i.User3)
                .Include(i => i.User4);

            Dictionary<string, decimal?> shiftsDict = new Dictionary<string, decimal?>();

            foreach (var shift in shifts)
            {
                var indicatorDay = _indicators.GetDayValueByDayNumber(shift.Date.Value.Day);
                var indicatorAB = (shift.AccountBalance == null ? 1 : shift.AccountBalance.Value) * shift.ShiftNumberNavigation.ShiftValueVal * indicatorDay;

                string s_username = $"{shift.User.UserName} {shift.User.Surname}";
                string s_user2name = $"{shift.User2.UserName} {shift.User2.Surname}";
                string s_user3name = $"{shift.User3.UserName} {shift.User3.Surname}";
                string s_user4name = $"{shift.User4.UserName} {shift.User4.Surname}";

                if (shiftsDict.ContainsKey(s_username))
                {
                    shiftsDict[s_username] += indicatorAB;
                }
                else
                {
                    shiftsDict.Add(s_username, indicatorAB);
                }

                if (shiftsDict.ContainsKey(s_user2name))
                {
                    shiftsDict[s_user2name] += indicatorAB;
                }
                else
                {
                    shiftsDict.Add(s_user2name, indicatorAB);
                }

                if (shiftsDict.ContainsKey(s_user3name))
                {
                    shiftsDict[s_user3name] += indicatorAB;
                }
                else
                {
                    shiftsDict.Add(s_user3name, indicatorAB);
                }

                if (shiftsDict.ContainsKey(s_user4name))
                {
                    shiftsDict[s_user4name] += indicatorAB;
                }
                else
                {
                    shiftsDict.Add(s_user4name, indicatorAB);
                }
            }

            shiftsDict.OrderByDescending(u => u.Value).ToList();

            BestUsersDTO bestUsersList = new BestUsersDTO() { BestUsers = new List<BestUserDTO>() };

            foreach (var item in shiftsDict)
            {
                var bestUser = new BestUserDTO()
                {
                    Username = item.Key,
                    Result = (int)item.Value
                };

                bestUsersList.BestUsers.Add(bestUser);
            }            

            return bestUsersList;
        }
    }
}

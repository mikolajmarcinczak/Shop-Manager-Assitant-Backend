using Microsoft.AspNetCore.Mvc;
using Shop_Manager_Assitant_Backend.Services.Interfaces;

namespace Shop_Manager_Assitant_Backend.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticsService _statistics;

        public StatisticController(IStatisticsService statistics)
        {
            _statistics = statistics;
        }

        [HttpGet]
        public ActionResult ShowBestShift()
        {
            return Json(_statistics.GetBestShifts().BestShifts);
        }

        [HttpGet]
        public ActionResult ShowBestUser(int cityId)
        {
            return Json(_statistics.GetBestUsersByCity(cityId).BestUsers);
        }
    }
}

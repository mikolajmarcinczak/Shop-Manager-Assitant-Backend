using Microsoft.AspNetCore.Mvc;
using Shop_Manager_Assitant_Backend.ModelsDTO;
using Shop_Manager_Assitant_Backend.Services.Interfaces;

namespace Shop_Manager_Assitant_Backend.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            this._shiftService = shiftService;
        }

        [HttpGet]
        public ShiftsDTO ShowSchedule(int cityId)
        {
            return _shiftService.ShowSchedule(cityId);
        }
    }
}

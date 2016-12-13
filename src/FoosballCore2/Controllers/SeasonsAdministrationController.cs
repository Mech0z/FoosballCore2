using System.Collections.Generic;
using FoosballCore2.RequestResponses;
using FoosballCore2.ViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace FoosballCore2.Controllers
{
    [Authorize(Policy = "Admin")]
    public class SeasonsAdministrationController : Controller
    {
        private readonly ISeasonLogic _seasonLogic;

        public SeasonsAdministrationController(ISeasonLogic seasonLogic)
        {
            _seasonLogic = seasonLogic;
        }
        
        public IActionResult Index()
        {
            List<Season> seasons = _seasonLogic.GetSeasons();

            var vm = new SeasonsAdministrationViewModel
            {
                Seasons = seasons
            };

            return View(vm);
        }
        
        [HttpPost]
        public ActionResult StartNewSeason(VoidRequest request)
        {
            var seasonName = _seasonLogic.StartNewSeason();

            return Ok(seasonName);
        }

        [HttpPost]
        public ActionResult GetSeasons(VoidRequest request)
        {
            List<Season> seasons = _seasonLogic.GetSeasons();
            return Ok(seasons);
        }
    }
}
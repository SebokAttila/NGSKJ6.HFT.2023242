using Microsoft.AspNetCore.Mvc;
using NGSKJ6.HFT._2023242.Logic.Interfaces;
using NGSKJ6.HFT._2023242.Models;
using System.Linq;

namespace NGSKJ6.HFT._2023242.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    public class StatsController : ControllerBase
    {
        IWineryLogic logic;

        public StatsController(IWineryLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IQueryable<Wine> ListByVintage(int vintage)
        {
            return logic.ListByVintage(vintage);
        }

        [HttpGet]
        public IQueryable<Barrell> BarrelsByMaterial(string material)
        {
            return logic.BarrellsByMaterial(material);
        }

        [HttpGet]
        public Wine BiggestBatch([FromQuery] string name)
        {
            return (Wine)logic.BiggestBatch(name);
        }

        [HttpGet]
        public IQueryable<Wine> WinesByWinery([FromQuery] string winery)
        {
            return logic.WinesByWinery(winery);
        }

        [HttpGet]
        public Barrell BiggestBarrelInWinery([FromQuery] string winery)
        {
            return logic.BiggestBarrelInWinery(winery);
        }
    }
}

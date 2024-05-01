using Microsoft.AspNetCore.Mvc;
using NGSKJ6.HFT._2023242.Logic.Interfaces;
using NGSKJ6.HFT._2023242.Models;
using System.Collections.Generic;

namespace NGSKJ6.HFT._2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WineryController : ControllerBase
    {
        IWineryLogic logic;

        public WineryController(IWineryLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Winery> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Winery Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Winery value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Winery value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

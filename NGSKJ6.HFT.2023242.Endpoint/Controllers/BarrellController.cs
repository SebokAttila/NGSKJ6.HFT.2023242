using Microsoft.AspNetCore.Mvc;
using NGSKJ6.HFT._2023242.Logic.Interfaces;
using NGSKJ6.HFT._2023242.Models;
using System.Collections.Generic;

namespace NGSKJ6.HFT._2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BarrellController : ControllerBase
    {
        IBarrellLogic logic;

        public BarrellController(IBarrellLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Barrell> ReadAll()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Barrell Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Barrell value)
        {
            this.logic.Create(value);
        }
        [HttpPut]
        public void Put([FromBody] Barrell value)
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

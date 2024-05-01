using NGSKJ6.HFT._2023242.Logic.Interfaces;
using NGSKJ6.HFT._2023242.Models;
using NGSKJ6.HFT._2023242.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Logic
{
    public class BarrellLogic : IBarrellLogic
    {
        IRepository<Barrell> repository;

        public BarrellLogic(IRepository<Barrell> repository)
        {
            this.repository = repository;
        }

        public void Create(Barrell item)
        {
            if (item.Type != Types.Barrique && item.Type != Types.Lager) { throw new Exception(); }
            if (item.Capacity <= 0 || (item.Type == Types.Barrique && item.Capacity > 250)) throw new FormatException();

            if (item.Material == null || item.Material == "")
            {
                throw new Exception();
            }
            this.repository.Create(item);
        }
        public void Delete(int id)
        {
            if (!repository.ReadAll().Select(p => p.BarrelId).Contains(id))
            {
                throw new FormatException();
            }
            this.repository.Delete(id);
        }

        public Barrell Read(int id)
        {
            return this.repository.Read(id);
        }
        public IQueryable<Barrell> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Barrell barrell)
        {
            this.repository.Update(barrell);
        }
    }
}

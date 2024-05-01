using NGSKJ6.HFT._2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Logic.Interfaces
{
    public interface IWineryLogic
    {
        void Create(Winery item);
        void Delete(int id);
        Winery Read(int id);
        IQueryable<Winery> ReadAll();
        void Update(Winery wine);
        public IQueryable<Wine> ListByVintage(int vintage);
        public IQueryable<Barrell> BarrellsByMaterial(string material);
        public Wine BiggestBatch(string name);
        public IQueryable<Wine> WinesByWinery(string winery);
        public Barrell BiggestBarrelInWinery(string winery);
    }
}

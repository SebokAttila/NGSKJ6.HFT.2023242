using NGSKJ6.HFT._2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Logic.Interfaces
{
    public interface IBarrellLogic
    {
        void Create(Barrell item);
        void Delete(int id);
        Barrell Read(int id);
        IQueryable<Barrell> ReadAll();
        void Update(Barrell barrell);
    }
}

using NGSKJ6.HFT._2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Logic.Interfaces
{
    public interface IWineLogic
    {
        void Create(Wine item);
        void Delete(int id);
        Wine Read(int id);
        IQueryable<Wine> ReadAll();
        void Update(Wine wine);
    }
}

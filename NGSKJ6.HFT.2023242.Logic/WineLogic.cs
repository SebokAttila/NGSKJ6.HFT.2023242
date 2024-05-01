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
    public class WineLogic : IWineLogic
    {
        IRepository<Wine> repository;

        public WineLogic(IRepository<Wine> repository)
        {
            this.repository = repository;
        }

        public void Create(Wine item)
        {


            if (item.Amount <= 0)
            {
                throw new Exception();
            }
            this.repository.Create(item);
        }
        public void Delete(int id)
        {
            if (!repository.ReadAll().Select(p => p.WineId).Contains(id))
            {
                throw new FormatException();
            }
            this.repository.Delete(id);
        }

        public Wine Read(int id)
        {
            return this.repository.Read(id);
        }
        public IQueryable<Wine> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Wine wine)
        {
            this.repository.Update(wine);
        }
    }
}

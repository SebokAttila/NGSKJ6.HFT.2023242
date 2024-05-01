using NGSKJ6.HFT._2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Repository
{
    public class WineRepository : Repository<Wine>
    {
        public WineRepository(WineryDbContext ctx) : base(ctx)
        {
        }
        public override Wine Read(int id)
        {
            return ctx.Wines.FirstOrDefault(p => p.WineId == id);
        }
        public override void Update(Wine entity)
        {
            var old = Read(entity.WineId);
            foreach (var item in entity.GetType().GetProperties())
            {
                item.SetValue(old, item.GetValue(entity));
            }
            ctx.SaveChanges();
        }
    }
}

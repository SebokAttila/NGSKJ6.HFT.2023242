using NGSKJ6.HFT._2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Repository
{
    public class WineryRepository : Repository<Winery>
    {
        public WineryRepository(WineryDbContext ctx) : base(ctx)
        {
        }
        public override Winery Read(int id)
        {
            return ctx.Wineries.FirstOrDefault(p => p.WineryId == id);
        }
        public override void Update(Winery entity)
        {
            var old = Read(entity.WineryId);
            foreach (var item in entity.GetType().GetProperties())
            {
                item.SetValue(old, item.GetValue(entity));
            }
            ctx.SaveChanges();
        }
    }
}

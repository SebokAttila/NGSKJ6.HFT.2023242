using NGSKJ6.HFT._2023242.Models;
using System;
using System.Linq;

namespace NGSKJ6.HFT._2023242.Repository
{
    public class BarrellRepository : Repository<Barrell>
    {
        public BarrellRepository(WineryDbContext ctx) : base(ctx)
        {
        }

        public override Barrell Read(int id)
        {
            return ctx.Barrels.FirstOrDefault(p => p.BarrelId == id);
        }

        public override void Update(Barrell entity)
        {
            var old = Read(entity.BarrelId);
            foreach (var item in entity.GetType().GetProperties())
            {
                item.SetValue(old, item.GetValue(entity));
            }
            ctx.SaveChanges();
        }
    }
}

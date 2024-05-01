using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected WineryDbContext ctx;
        public Repository(WineryDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }
        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }
        public abstract T Read(int id);
        public abstract void Update(T entity);
    }
}

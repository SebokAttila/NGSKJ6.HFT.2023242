using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Repository
{
    public interface IRepository <T> where T : class
    {
        IQueryable<T> ReadAll();
        T Read(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

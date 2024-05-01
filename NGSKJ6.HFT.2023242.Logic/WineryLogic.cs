using NGSKJ6.HFT._2023242.Logic.Interfaces;
using NGSKJ6.HFT._2023242.Models;
using NGSKJ6.HFT._2023242.Repository;
using System;
using System.Linq;

namespace NGSKJ6.HFT._2023242.Logic
{
    public class WineryLogic : IWineryLogic
    {
        IRepository<Winery> repository;

        public WineryLogic(IRepository<Winery> repository)
        {
            this.repository = repository;
        }
        public void Create(Winery item)
        {
            if (item.Name.Length < 0 || item.Name.Length > 99) throw new FormatException();

            if (item.Location == null || item.Location == "")
            {
                throw new Exception();
            }
            this.repository.Create(item);
        }
        public void Delete(int id)
        {
            if (!repository.ReadAll().Select(p => p.WineryId).Contains(id))
            {
                throw new FormatException();
            }
            this.repository.Delete(id);
        }
        public Winery Read(int id)
        {
            return this.repository.Read(id);
        }
        public IQueryable<Winery> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Winery wine)
        {
            this.repository.Update(wine);
        }
        public IQueryable<Wine> ListByVintage(int vintage)
        {
            var vintageWines = from w in repository.ReadAll()
                               from wine in w.Wines
                               where wine.Vintage == vintage
                               select wine; return vintageWines;
        }
        public IQueryable<Barrell> BarrellsByMaterial(string material)
        {
            var barrelList = from w in repository.ReadAll()
                             from wine in w.Wines
                             from b in wine.Barells
                             where b.Material == material
                             select b; return barrelList;
        }
        public Wine BiggestBatch(string name)
        {
            var biggestbatch = from w in repository.ReadAll()
                               from wine in w.Wines
                               where w.Name == name
                               orderby wine.Amount descending
                               select wine;
            return biggestbatch.First();
        }
        public IQueryable<Wine> WinesByWinery(string winery)
        {
            var wines = from w in repository.ReadAll()
                        where w.Name == winery
                        from wine in w.Wines
                        select wine; return wines;
        }
        public Barrell BiggestBarrelInWinery(string winery)
        {
            var biggest = from w in repository.ReadAll()
                          from wine in w.Wines
                          from b in wine.Barells
                          where w.Name == winery
                          orderby b.Capacity descending
                          select b; return biggest.First();
        }
    }
}

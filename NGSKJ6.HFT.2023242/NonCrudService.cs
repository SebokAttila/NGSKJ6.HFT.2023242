using NGSKJ6.HFT._2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242
{
    public class NonCrudService
    {
        private RestService restService;

        public NonCrudService(RestService restService)
        {
            this.restService = restService;
        }
        public void ListByVintage()
        {
            Console.WriteLine("Vintage:");
            string vintage = Console.ReadLine();
            var items = restService.Get<Wine>($"Stats/ListByVintage?vintage={vintage}");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        public void BarrelsByMaterial()
        {
            Console.WriteLine("Material:");
            string material = Console.ReadLine();
            var barrels = restService.Get<Barrell>($"Stats/BarrelsByMaterial?material={material}");
            foreach (var item in barrels)
            {
                Console.WriteLine(item.BarrelId + "\t" + item.Capacity);
            }
            Console.ReadLine();
        }
        public void BiggestBatch()
        {
            Console.WriteLine("Winery:");
            string winery = Console.ReadLine();
            var biggest = restService.GetSingle<Wine>($"Stats/BiggestBatch?name={winery}");
            Console.WriteLine(biggest.Name);
            Console.ReadLine();
        }
        public void WinesByWinery()
        {
            Console.WriteLine("Winery");
            string winery = Console.ReadLine();
            var wines = restService.Get<Wine>($"Stats/WinesByWinery?winery={winery}");
            foreach (var item in wines)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        public void BiggestBarrelInWinery()
        {
            Console.WriteLine("Winery");
            string winery = Console.ReadLine();
            var barrel = restService.GetSingle<Barrell>($"Stats/BiggestBarrelInWinery?winery={winery}");
            Console.WriteLine(barrel.BarrelId);
            Console.ReadLine();
        }
    }
}

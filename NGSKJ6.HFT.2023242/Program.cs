using ConsoleTools;
using NGSKJ6.HFT._2023242.Models;
using System;

namespace NGSKJ6.HFT._2023242
{
    class Program
    {
        static RestService RestService;
        static void Main(string[] args)
        {
            RestService = new RestService("http://localhost:20704/", "Winery");
            CrudService crud = new CrudService(RestService);
            NonCrudService noncrud = new NonCrudService(RestService);

            var WineryMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Winery>())
                .Add("Create", () => crud.Create<Winery>())
                .Add("Delete", () => crud.Delete<Winery>())
                .Add("Update", () => crud.Update<Winery>())
                .Add("Exit", ConsoleMenu.Close);
            var WineMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Wine>())
                .Add("Create", () => crud.Create<Wine>())
                .Add("Delete", () => crud.Delete<Wine>())
                .Add("Update", () => crud.Update<Wine>())
                .Add("Exit", ConsoleMenu.Close);
            var BarrelMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Barrell>())
                .Add("Create", () => crud.Create<Barrell>())
                .Add("Delete", () => crud.Delete<Barrell>())
                .Add("Update", () => crud.Update<Barrell>())
                .Add("Exit", ConsoleMenu.Close);
            var StatsMenu = new ConsoleMenu(args, level: 1)
                .Add("ListByVintage", () => noncrud.ListByVintage())
                .Add("BiggestBatch", () => noncrud.BiggestBatch())
                .Add("WinesByWinery", () => noncrud.WinesByWinery())
                .Add("BiggestBarrelInWinery", () => noncrud.BiggestBarrelInWinery())
                .Add("BarrelsByMaterial", () => noncrud.BarrelsByMaterial())
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Wineries", () => WineryMenu.Show())
                .Add("Wines", () => WineMenu.Show())
                .Add("Barrels", () => BarrelMenu.Show())
                .Add("Stats", () => StatsMenu.Show());
            menu.Show();
        }
    }
}

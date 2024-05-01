using Moq;
using NGSKJ6.HFT._2023242.Logic;
using NGSKJ6.HFT._2023242.Models;
using NGSKJ6.HFT._2023242.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NGSKJ6.HFT._2023242.Test
{
    public class Tests
    {
        [TestFixture]
        public class UnitTest
        {
            WineryLogic wineryLogic;
            WineLogic wineLogic;
            BarrellLogic barrelLogic;
            Mock<IRepository<Winery>> mockWineryRepository;
            Mock<IRepository<Wine>> mockWineRepository;
            Mock<IRepository<Barrell>> mockBarrellRepository;
            Winery winery;
            Wine wine;
            Barrell barrell;
            [SetUp]
            public void Setup()
            {
                mockWineryRepository = new Mock<IRepository<Winery>>();
                mockWineRepository = new Mock<IRepository<Wine>>();
                mockBarrellRepository = new Mock<IRepository<Barrell>>();

                winery = new Winery();
                winery.Name = "Borház1";
                winery.Location = "Borvidék1";
                winery.Wines = new List<Wine>();

                wine = new Wine();
                wine.Name = "Kékfrankos";
                wine.Type = "Vörös";
                wine.Vintage = 2020;
                wine.Amount = 100;
                wine.WineryId = 1;
                wine.Barells = new List<Barrell>();

                barrell = new Barrell();
                barrell.Capacity = 200;
                barrell.Material = "Tölgyfa";
                barrell.NumberOfUses = 5;
                barrell.Type = Types.Barrique;
                barrell.WineId = 1;

                barrell.Wine = wine;
                wine.Barells.Add(barrell);
                winery.Wines.Add(wine);
                Winery winery2 = new Winery
                {
                    WineryId = 2,
                    Name = "Másik Borház",
                    Location = "Másik Borvidék",
                    Wines = new List<Wine>()
                };
                Wine wine2 = new Wine
                {
                    WineId = 2,
                    Name = "Cabernet Sauvignon",
                    Type = "Vörös",
                    Vintage = 2018,
                    Amount = 120,
                    WineryId = 2,
                    Barells = new List<Barrell>()
                };
                Barrell barrell2 = new Barrell
                {
                    BarrelId = 2,
                    Capacity = 180,
                    Material = "Akácfa",
                    NumberOfUses = 4,
                    Type = Types.Barrique,
                    WineId = 2
                };
                barrell2.Wine = wine2;
                wine2.Barells.Add(barrell2);
                winery2.Wines.Add(wine2);
                List<Winery> wineries = new List<Winery> { winery, winery2 };
                List<Wine> wines = new List<Wine> { wine, wine2 };
                List<Barrell> barrels = new List<Barrell> { barrell, barrell2 };

                mockWineryRepository.Setup(w => w.ReadAll()).Returns(wineries.AsQueryable);
                mockWineRepository.Setup(w => w.ReadAll()).Returns(wines.AsQueryable);
                mockBarrellRepository.Setup(b => b.ReadAll()).Returns(barrels.AsQueryable);

                wineryLogic = new WineryLogic(mockWineryRepository.Object);
                wineLogic = new WineLogic(mockWineRepository.Object);
                barrelLogic = new BarrellLogic(mockBarrellRepository.Object);
            }
            [Test]
            public void TestListByVintage_ReturnsCorrectVintageWines()
            {
                int vintageToTest = 2020;

                var result = wineryLogic.ListByVintage(vintageToTest);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.All(w => w.Vintage == vintageToTest));
            }
            [Test]
            public void TestBarrellsByMaterial_ReturnsCorrectMaterialBarrels()
            {
                string materialToTest = "Tölgyfa";

                var result = wineryLogic.BarrellsByMaterial(materialToTest);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.All(b => b.Material == materialToTest));
            }
            [Test]
            public void TestBarrellsByMaterial_ReturnsCorrectMaterialBarrels2()
            {
                string materialToTest = "Birch";

                var result = wineryLogic.BarrellsByMaterial(materialToTest);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.All(b => b.Material == materialToTest));
            }
            [Test]
            public void TestWinesByWinery_ReturnsWinesForWinery()
            {
                string wineryNameToTest = "Borház1";

                var result = wineryLogic.WinesByWinery(wineryNameToTest);

                Assert.IsNotNull(result);
            }
            [Test]
            public void TestBiggestBarrelInWinery_ReturnsBiggestBarrelForWinery()
            {
                string wineryNameToTest = "Borház1";

                var result = wineryLogic.BiggestBarrelInWinery(wineryNameToTest);

                Assert.IsNotNull(result);
            }
            [Test]
            public void TestListByVintage_ReturnsEmptyListForNonExistingVintage()
            {
                int nonExistingVintage = 2019;

                var result = wineryLogic.ListByVintage(nonExistingVintage);

                Assert.IsNotNull(result);
                Assert.IsFalse(result.Any());
            }
            [Test]
            public void TestBarrellsByMaterial_ReturnsEmptyListForNonExistingMaterial()
            {
                string nonExistingMaterial = "Fém";

                var result = wineryLogic.BarrellsByMaterial(nonExistingMaterial);

                Assert.IsNotNull(result);
                Assert.IsFalse(result.Any());
            }
            [Test]
            public void WineryCreateTester()
            {
                Winery winery = new Winery() { WineryId = 1, Name = "Gere", Location = "Villány" };
                wineryLogic.Create(winery);
                mockWineryRepository.Verify(w => w.Create(winery), Times.Once);
                Assert.IsNotNull(winery);
            }
            [Test]
            public void WineCreateTester()
            {
                Wine wine = new Wine() { WineId = 1, Amount = 150, Name = "bor", Type = "Vörös", Vintage = 1996 };
                wineLogic.Create(wine);
                mockWineRepository.Verify(w => w.Create(wine), Times.Once);
                Assert.IsNotNull(wine);
            }

            [Test]
            public void BarrelCreateTester()
            {
                Barrell barrell = new Barrell() { BarrelId = 1, Capacity = 150, Material = "Oak", NumberOfUses = 4, Type = Types.Barrique };
                barrelLogic.Create(barrell);
                mockBarrellRepository.Verify(b => b.Create(barrell), Times.Once);
                Assert.IsNotNull(barrell);
            }
        }
    }
}
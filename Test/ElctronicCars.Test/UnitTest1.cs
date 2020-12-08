using NUnit.Framework;
using AutoMapper;
using ElectronicCars.Core;
using ElectronicCars.Extensions;
using ElectronicCars.Controllers.Resources;
using ElectronicCars.Core.Models;
using System.Net.Http;
using System.Collections.Generic;

namespace ElctronicCars.Test
{
    public class Tests
    {
        // [SetUp]
        // public void Setup()
        // {
        // }
        private readonly IMapper mapper;
        private readonly ISaleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        [Test]
        public async void Test1()
        {
            // arrange
            var controller = new ElectronicCars.Controllers.SalesController(mapper, repository, unitOfWork);
            // act
            var locations = new List<SalesLocation>() { new SalesLocation() { Id = 3, LocationName = "BridgeView" }, new SalesLocation() { Id = 4, LocationName = "BridgeView" } };
            var months = new List<SaleQueryMonths>() { new SaleQueryMonths() { Year = 2020, Month = 12 } };
            var requertBody = new SaleQueryResource() { Locations = locations, Months = months };
            var result = await controller.GetSales(requertBody);
            // Assert
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void PostSetsLocationHeader()
        {
            Assert.Pass();
        }
    }
}
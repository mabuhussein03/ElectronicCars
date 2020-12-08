using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using ElectronicCars.Core;
using ElectronicCars.Extensions;
using ElectronicCars.Controllers.Resources;
using ElectronicCars.Core.Models;
namespace ElectronicCars.Controllers
{
    [ApiController]
    [Route("api/saleslocation")]
    public class LocationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILocationRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public LocationController(IMapper mapper, ILocationRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSaleLocation([FromBody] SalesLocationResource saleLocationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var salesLocation = mapper.Map<SalesLocationResource, SalesLocation>(saleLocationResource);

            repository.Add(salesLocation);
            await unitOfWork.CompleteAsync();

            salesLocation = await repository.GetSaleLocation(salesLocation.Id);

            var result = mapper.Map<SalesLocation, SalesLocationResource>(salesLocation);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, [FromBody] SalesLocationResource saleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var salesLocation = await repository.GetSaleLocation(id);

            if (salesLocation == null)
                return NotFound();

            mapper.Map<SalesLocationResource, SalesLocation>(saleResource, salesLocation);

            await unitOfWork.CompleteAsync();

            salesLocation = await repository.GetSaleLocation(salesLocation.Id);
            var result = mapper.Map<SalesLocation, SalesLocationResource>(salesLocation);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var salesLocation = await repository.GetSaleLocation(id, includeRelated: false);

            if (salesLocation == null)
                return NotFound();

            repository.Remove(salesLocation);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            var salesLocation = await repository.GetSaleLocation(id);

            if (salesLocation == null)
                return NotFound();

            var vehicleResource = mapper.Map<SalesLocation, SalesLocationResource>(salesLocation);

            return Ok(vehicleResource);
        }
        [HttpGet]
        public async Task<QueryResult<SalesLocation>> GetSales()
        {
            var queryResult = await repository.GetSalesLocation();
            return queryResult;
            // return mapper.Map<QueryResult<Sale>, QueryResultResource<SaleResource>>(queryResult);
        }

    }
}
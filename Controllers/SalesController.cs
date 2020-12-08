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
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISaleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public SalesController(IMapper mapper, ISaleRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaleResource saleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sale = mapper.Map<SaleResource, Sale>(saleResource);
            sale.LastUpdate = DateTime.Now;

            repository.Add(sale);
            await unitOfWork.CompleteAsync();

            sale = await repository.GetSale(sale.Id);

            var result = mapper.Map<Sale, SaleResource>(sale);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, [FromBody] SaleResource saleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sale = await repository.GetSale(id);

            if (sale == null)
                return NotFound();

            mapper.Map<SaleResource, Sale>(saleResource, sale);
            sale.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            sale = await repository.GetSale(sale.Id);
            var result = mapper.Map<Sale, SaleResource>(sale);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await repository.GetSale(id, includeRelated: false);

            if (sale == null)
                return NotFound();

            repository.Remove(sale);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            var sale = await repository.GetSale(id);

            if (sale == null)
                return NotFound();

            var vehicleResource = mapper.Map<Sale, SaleResource>(sale);

            return Ok(vehicleResource);
        }
        [HttpGet]
        public async Task<ICollection<SalesQueryResult>> GetSales(SaleQueryResource filterResource)
        {
            var filter = mapper.Map<SaleQueryResource, SaleQuery>(filterResource);
            var queryResult = await repository.GetSales(filter);
            return queryResult;
            // return mapper.Map<QueryResult<Sale>, QueryResultResource<SaleResource>>(queryResult);
        }

    }
}
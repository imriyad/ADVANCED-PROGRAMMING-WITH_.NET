using CRMSystem.BLL.DTOs;
using CRMSystem.BLL.Interfaces;
using System;
using System.Web.Http;

namespace CRMSystem.Controllers
{
    public class SalesController : ApiController
    {
        private readonly ISaleService service;

        public SalesController(ISaleService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("api/sales")]
        public IHttpActionResult Get() => Ok(service.Get());

        [HttpGet]
        [Route("api/sales/{id}")]
        public IHttpActionResult Get(int id)
        {
            var sale = service.Get(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }

        [HttpPost]
        [Route("api/sales")]
        public IHttpActionResult Create([FromBody] SaleDTO sale)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            service.Create(sale);
            return Ok("Sale created");
        }

        [HttpPut]
        [Route("api/sales")]
        public IHttpActionResult Update([FromBody] SaleDTO sale)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            service.Update(sale);
            return Ok("Sale updated");
        }

        [HttpDelete]
        [Route("api/sales/{id}")]
        public IHttpActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok("Sale deleted");
        }
        [HttpGet]
        [Route("api/sales/filter")]

        //for postman : https://localhost:44389/api/sales/filter?leadId=5&fromDate=2025-04-23T00:00:00&toDate=2025-07-24T00:00:00
        public IHttpActionResult Filter(int? leadId = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var filteredSales = service.GetFiltered(leadId, fromDate, toDate);
            return Ok(filteredSales);
        }
        [HttpGet]
        [Route("api/sales/report")]
        public IHttpActionResult GetReport()
        {
            var data = service.GetSalesReport();
            return Ok(data);
        }


    }
}

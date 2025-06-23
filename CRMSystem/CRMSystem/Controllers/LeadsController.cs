using CRMSystem.BLL.DTOs;        
using CRMSystem.BLL.interfaces;
using System.Net;
using System.Web.Http;

namespace CRMSystem.Controllers
{
    public class LeadsController : ApiController
    {
        private readonly ILeadService service;

        // Constructor injection
        public LeadsController(ILeadService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("api/leads")]
        public IHttpActionResult Get() => Ok(service.Get());

        [HttpGet]
        [Route("api/leads/{id}")]
        public IHttpActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [Route("api/leads")]
        public IHttpActionResult Create([FromBody] LeadDTO lead)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            service.Create(lead);
            return Ok("Lead created");
        }

        [HttpPut]
        [Route("api/leads")]
        public IHttpActionResult Update([FromBody] LeadDTO lead)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            service.Update(lead);
            return Ok("Lead updated");
        }

        [HttpDelete]
        [Route("api/leads/{id}")]
        public IHttpActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok("Lead deleted");
        }
    }
}

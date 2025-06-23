using CRMSystem.BLL.DTOs;
using CRMSystem.BLL.Interfaces;
using System.Web.Http;

namespace CRMSystem.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactService service;

        public ContactsController(IContactService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("api/contacts")]
        public IHttpActionResult Get() => Ok(service.Get());

        [HttpGet]
        [Route("api/contacts/{id}")]
        public IHttpActionResult Get(int id)
        {
            var contact = service.Get(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        [Route("api/contacts")]
        public IHttpActionResult Create([FromBody] ContactDTO contact)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            service.Create(contact);
            return Ok("Contact created");
        }

        [HttpPut]
        [Route("api/contacts")]
        public IHttpActionResult Update([FromBody] ContactDTO contact)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            service.Update(contact);
            return Ok("Contact updated");
        }

        [HttpDelete]
        [Route("api/contacts/{id}")]
        public IHttpActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok("Contact deleted");
        }
    }
}

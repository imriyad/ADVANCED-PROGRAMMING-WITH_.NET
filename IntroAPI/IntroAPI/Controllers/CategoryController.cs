using IntroAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class CategoryController : ApiController
    {
        PMSEntities db = new PMSEntities();
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage GetAll()
        {
            var data = db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = db.Categories.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage Create(Category c)
        {
            c.CreatedAt = DateTime.Now;
            c.CreatedBy = 99;
            db.Categories.Add(c);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, "Category Created");
        }

        [HttpPut]
        [Route("api/category/update/{id}")]
        public HttpResponseMessage Update(int id, Category updatedCategory)
        {
            var existingCategory = db.Categories.Find(id);
            if (existingCategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Category not found");
            }

            // Only updating the Name since no UpdatedAt/UpdatedBy in model
            existingCategory.Name = updatedCategory.Name;

            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Category Updated");
        }

        [HttpDelete]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Category not found");
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Category Deleted");
        }


    }
}
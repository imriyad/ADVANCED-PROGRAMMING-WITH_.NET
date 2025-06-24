using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CRMSystem.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        [Route("api/file/upload")]
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "Invalid request");
            }

            var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");
            var provider = new MultipartFormDataStreamProvider(uploadPath);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                string fileName = provider.FileData[0].Headers.ContentDisposition.FileName.Trim('\"');
                string filePath = provider.FileData[0].LocalFileName;

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    message = "File uploaded successfully",
                    fileName = fileName,
                    savedPath = "/Uploads/" + fileName
                });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}

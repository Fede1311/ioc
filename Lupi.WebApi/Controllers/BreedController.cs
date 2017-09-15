using Lupi.BusinessLogic;
using Lupi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Lupi.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class BreedController : CommonApiController
    {
        private BreedBusinessLogic businessLogic;
        public BreedController()
        {
            businessLogic = new BreedBusinessLogic();
        }

        // GET: api/Breeds
        public IHttpActionResult Get()
        {

            return Ok(businessLogic.Get());

        }

        // GET: api/Breed/5
        public IHttpActionResult Get(Guid id)
        {
            return Ok(businessLogic.Get(id));
            
        }

        // POST: api/Breed
        public void Post([FromBody] Breed breed)
        {
            businessLogic.Add(breed);
        }


        [Route("breed/{breedId:guid}/hairs/{hairId:int}")]
        [HttpGet]
        public IHttpActionResult Get(Guid breedId, int hairId)
        {
            if(hairId == 1)
            {
                return Ok("Wonderful redish color!");
            }
            return NotFound();

            /*HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Test");
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20),
            };
            return response;*/

            //return new ForbiddenResult(Request, "Because I say so");
        }

        // PUT: api/Breed/5
        public void Put(Guid id, [FromBody]Breed breed)
        {
        }

        // DELETE: api/Breed/5
        public void Delete(int id)
        {
        }
    }
}

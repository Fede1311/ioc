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
        private IBreedBusinessLogic businessLogic { get; set; }

        public BreedController(IBreedBusinessLogic breedLogic)
        {
            businessLogic = breedLogic;
        }

        // GET: api/Breeds
        public IHttpActionResult Get()
        {
            IEnumerable<Breed> breeds = businessLogic.Get();
            if (breeds == null)
            {
                return NotFound();
            }
            return Ok(breeds);
        }

        // GET: api/Breed/5
        public IHttpActionResult Get(Guid id)
        {
            return Ok(businessLogic.Get(id));
            
        }

        // POST: api/Breed
        public IHttpActionResult Post([FromBody] Breed breed)
        {
            try
            {
                Guid id = businessLogic.Add(breed);
                return CreatedAtRoute("DefaultApi", new { id = id }, breed);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Breed/5
        public IHttpActionResult Put(Guid id, [FromBody]Breed breed)
        {
            try
            {
                bool updateResult = businessLogic.Update(id, breed);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, breed);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Breed/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                bool updateResult = businessLogic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("breed/{breedId:guid}/hairs/{hairId:int}")]
        [HttpGet]
        public IHttpActionResult Get(Guid breedId, int hairId)
        {
            if (hairId == 1)
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
    }
}

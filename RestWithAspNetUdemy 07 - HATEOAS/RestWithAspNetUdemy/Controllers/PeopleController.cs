using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Models;
using RestWithAspNetUdemy.Services;
using Tapioca.HATEOAS;

namespace RestWithAspNetUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PeopleController : Controller
    {
        IPersonBusiness _personService;

        public PeopleController(IPersonBusiness personService)
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet("{page}/{pagesize}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int page, int pageSize)
        {
            return Ok(_personService.FindAll(page, pageSize));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return new OkObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]Person personUpdate)
        {
            if (personUpdate == null)
            {
                return BadRequest();
            }

            var person = _personService.Update(personUpdate);

            if (person != null)
                return new OkObjectResult(person);
            else
                return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);

            return NoContent();
        }
    }
}

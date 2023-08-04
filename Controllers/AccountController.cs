using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Bll;
using NetCoreApi.Models;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {   
       


        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post([FromBody] AccountModel model)
        {
            if (ModelState.IsValid)
            {
            AccountBll.Save(model);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AccountModel model)
        {
            AccountBll.Save(model);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

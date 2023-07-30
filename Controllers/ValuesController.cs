using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Models;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ValuesController : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<TesterModel> GetTester() => Ok(new TesterModel());

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<TesterModel> CreateTester([FromBody] TesterModel model)
        {
            return CreatedAtRoute("GetTester", model);
        }

    }
}

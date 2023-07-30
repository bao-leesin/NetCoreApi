using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Models;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ValuesController : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = "GetTest")]

        public ActionResult<TesterModel> GetTester() => Ok(new TesterModel());

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<TesterModel> CreateTester([FromBody] TesterModel model)
        {
            //bool caseHasError = true;
            //if (caseHasError)
            //{
            //    ModelState.AddModelError("Custom Error", "Error message");
            //    return BadRequest(ModelState);
            //}
            return CreatedAtRoute("GetTest",model);
        }

    }
}

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Models;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ValuesController : ControllerBase
    {

        private readonly ILogger<AccountModel> _logger;
        public ValuesController(ILogger<AccountModel> logger)
        {
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = "GetTest")]
        public ActionResult<AccountModel> GetTester()
        {
            _logger.LogInformation("TestLog");
            AccountModel value = new AccountModel();
            return Ok(value);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<AccountModel> CreateTester([FromBody] AccountModel model)
        {
            //bool caseHasError = true;
            //if (caseHasError)
            //{
            //    ModelState.AddModelError("Custom Error", "Error message");
            //    return BadRequest(ModelState);
            //}
            return CreatedAtRoute("GetTest",model);
        }
        [HttpPatch]
        public IActionResult TestPatch(int id, JsonPatchDocument<AccountModel> patch)
        {
            AccountModel X = new AccountModel { Id = id};
            patch.ApplyTo(X, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            var smt = ModelState.IsValid;
            return Ok(smt);
        }
       
    }
}

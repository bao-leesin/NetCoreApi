﻿using Microsoft.AspNetCore.JsonPatch;
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
        [HttpPatch]
        public IActionResult TestPatch(int id, JsonPatchDocument<TesterModel> patch)
        {
            TesterModel X = new TesterModel { Id = id};
            patch.ApplyTo(X, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            var smt = ModelState.IsValid;
            return Ok(smt);
        }
       
    }
}

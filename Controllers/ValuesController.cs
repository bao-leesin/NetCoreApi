﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
     
        public ActionResult testStatus()
        {

            return ViewComponent();
        }

        private ActionResult ViewComponent()
        {
            throw new NotImplementedException();
        }
    }
}
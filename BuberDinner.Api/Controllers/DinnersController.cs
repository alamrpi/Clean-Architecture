﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DinnersController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Array.Empty<string>());
        }
    }
}

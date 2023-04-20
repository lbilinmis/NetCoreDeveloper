﻿using Microsoft.AspNetCore.Mvc;

namespace RateLimitApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPrpduct()
        {

            return Ok(new { Id = 1, Name = "Kalem", Price = 10 });
        }
    }
}

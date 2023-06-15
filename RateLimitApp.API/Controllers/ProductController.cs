using Microsoft.AspNetCore.Mvc;

namespace RateLimitApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {

            return Ok(new { Id = 1, Name = "Kalem", Price = 10 });
        }

        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {//parametre alan bir metod nasıl yapılacağı örneği
            return Ok(name);
        }


        [HttpPost]
        public IActionResult SaveProduct()
        {

            return Ok(new { status = "success" });
        }


        [HttpPut]
        public IActionResult UpdateProduct()
        {

            return Ok();
        }
    }
}

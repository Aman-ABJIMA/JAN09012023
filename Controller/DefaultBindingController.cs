using Microsoft.AspNetCore.Mvc;
using WEB_API3.Models;

namespace WEB_API3.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultBindingController : ControllerBase
    {
        #region Using Quary Method:
       
      
        [HttpGet("")]
        public IActionResult Index(string name,int id)
        {
            return Ok($"Name:{name}\nId:{id}");
        }

   
        #endregion

        #region Using Route Method:
        [HttpGet("{name}/{id}")]
        public IActionResult Index2(string name, int id)
        {
            return Ok($"Name:{name}\nId:{id}");
        }
        #endregion

        #region
        [HttpPost("")]
        public IActionResult Index3([FromQuery]CountryModel name)
        {
            return Ok($"Name={name.Name}");
        }
        #endregion

        #region
        [HttpPost("{name}")]
        public IActionResult Index4([FromRoute] string name)
        {
            return Ok($"Name={name}");
        }
        #endregion


        #region
        [HttpPost("{id}")]
        public IActionResult Index5([FromBody]int id)
        {
            return Ok($"ID={id}");
        }
        #endregion

        #region
        [HttpPost("FromForm/{id}")]
        public IActionResult Index6(int id, [FromForm] CountryModel model)
        {
            return Ok($"ID={id}\nCountry:{model.Name}");
        }
        #endregion
    }
}

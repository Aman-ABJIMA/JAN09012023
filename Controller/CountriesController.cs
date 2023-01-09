using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WEB_API3.Models;

namespace WEB_API3.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [BindProperties(SupportsGet = true)]
    public class CountriesController : ControllerBase
    {
       // [BindProperty]  //Binding The Country Property with http request data
        public CountryModel Country { get; set; }
        //[HttpPost("")]
        [HttpGet]
        public IActionResult AddCountry()
        {
            return Ok($"CountryCode:{this.Country.CountryCode}\nCountry:{this.Country.Name}");
        }
    }

    
    
}

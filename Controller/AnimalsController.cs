using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.Linq;
using WEB_API3.Models;

namespace WEB_API3.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        public List<AnimalModel> animals = null;
        public AnimalsController() 
        {
            animals = new List<AnimalModel>()
            {
                new AnimalModel(){Id=1,Name="Cat"},
                new AnimalModel(){Id=2,Name="Dog"},
                new AnimalModel(){Id=3,Name="Lion"}
            };
        }
      public IActionResult GetAnimals()
        {
            //var animals = new List<AnimalModel>()
            //{ 
            //    new AnimalModel(){Id=1,Name="Cat"},
            //    new AnimalModel(){Id=2,Name="Dog"}
            //};
            return Ok(animals);   //Produces 200 OK response !!!
        }
        [Route("test1")]
        public IActionResult GetAnimalTest() 
        {
            //var animals = new List<AnimalModel>()
            //{
            //new AnimalModel(){Id=1,Name="Dog" },
            //new AnimalModel(){Id=2,Name="Cat"},
            //new AnimalModel(){Id=3,Name="Lion"}
            //};
            return Accepted(animals);   //Produces 202 Accepted response!!!
        }

        [Route("test2")]
        public IActionResult GetAnimalTest2()
        {
            //var animals = new List<AnimalModel>()
            //{
            //new AnimalModel(){Id=1,Name="Dog" },
            //new AnimalModel(){Id=2,Name="Cat"},
            //new AnimalModel(){Id=3,Name="Lion"}
            //};
            return AcceptedAtAction("GetAnimals");   //It indicates the URL to redirect the page to!!! 
        }

        [Route("{name}")]
        public IActionResult GetAnimalByName(string name)
        {
            if (!name.Contains("!"))
                return BadRequest();     //Produces 400 Bad Request Status Code!!!
            return Ok(animals);     
        }

        [Route("{id:int}")]
        public IActionResult GetAnimalById(int id)
        {
            if (id==0)
                return BadRequest();     //Produces 400 Bad Request Status Code!!!
            var animal = animals.FirstOrDefault(x => x.Id==id);
            if(animal==null)
                return NoContent();

            return Ok(animals.FirstOrDefault(x=>x.Id == id));
        }

        [HttpPost("")]
        public IActionResult AddAnimals(AnimalModel animal)
        {
            animals.Add(animal);
            return Created("~/api/animals/"+animal.Id,animal);
        }
        [Route("",Name ="All")]
        public IActionResult GetAnimal()
        {
            return Ok(animals);
        }
        [Route("test3")]
        public IActionResult GetAnimalsTest3()
        {
            return LocalRedirect("~/api/animals/test1");
        }


        [Route("test4")]
        public IActionResult GetAnimalsTest4()
        {
            return LocalRedirectPermanent("~/api/animals/test2");
        }


    }
}

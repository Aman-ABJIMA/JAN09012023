using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WEB_API3.Models;

namespace WEB_API3.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [Route("get")]
        public EmployeeModel GetEmployees() => new EmployeeModel()
        {
            Id = 10005,
            Name = "AMAN SINGH"
        };



        [Route("get-list")]
        public List<EmployeeModel> GetListEmployees() => new List<EmployeeModel>()
        {
           new EmployeeModel{ Id = 10005,Name = "AMAN SINGH"},
           new EmployeeModel{ Id = 10006,Name = "KULDEEP SINGH"},
           new EmployeeModel{ Id = 10007,Name = "ISHANSHI AGRAWAL"},
           new EmployeeModel{ Id = 10008,Name = "DIVYA UDAYAN"}
        };


        [Route("{id}")]
        public IActionResult GetIEmployees(int id)
        {
           if (id == 0)
           return NotFound();
           
           return Ok(new List<EmployeeModel>()
           {
           new EmployeeModel{ Id = 10005,Name = "AMAN SINGH"},
           new EmployeeModel{ Id = 10006,Name = "KULDEEP SINGH"},
           new EmployeeModel{ Id = 10007,Name = "ISHANSHI AGRAWAL"},
           new EmployeeModel{ Id = 10008,Name = "DIVYA UDAYAN"}
           });
        }


        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmpoBasicDetails(int id)
        {
            
            if (id == 10005)
            { 
                return  new EmployeeModel()
                {
                Id = 10005,
                Name = "AMAN SINGH"
                };
            }
            return NotFound();
        }
    }
}

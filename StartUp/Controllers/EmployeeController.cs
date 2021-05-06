using Microsoft.AspNetCore.Mvc;
using StartUp.Models;
using System.Collections.Generic;
using System.Linq;

namespace StartUp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        public IEnumerable<Employee> Get()
        {
            using (var contxt = new WebApiContext())
            {
                return contxt.Employees.ToList();

            }
        }
        [HttpGet("{id}")]
        public IEnumerable<Employee> Get(int id)
        {
            using (var contxt = new WebApiContext())
            {
                return contxt.Employees.Where(e => e.Id == id);

            }
        }
        // POST api/<controller>
        [HttpPost]

        public void Post([FromBody] Employee employee)
        {
            using (var contxt = new WebApiContext())
            {
                if (ModelState.IsValid)
                {
                    contxt.Employees.Add(employee);
                    contxt.SaveChanges();
                }




            }
        }
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                // return BadRequest("Not a valid data");

                using (var contxt = new WebApiContext())
                {
                    var emp = contxt.Employees.Where(e => e.Id == id).FirstOrDefault<Employee>();

                    if (emp != null)
                    {
                        emp.Name = employee.Name;
                        emp.Address = employee.Address;

                        emp.SaveChanges();
                    }
                    else
                    {
                        // return NotFound();
                    }
                }
            // return Ok();

        }
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var contxt = new WebApiContext())
            {
                var emp = contxt.Employees.Where(e => e.Id == id).FirstOrDefault<Employee>();

                if (emp != null)
                {
                    contxt.Employees.Remove(emp);
                    contxt.SaveChanges();
                  //  return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                   // return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                 //"Employee with Id = " + id.ToString() + " not found to delete");
                }

                   // emp.SaveChanges();
                
            }

        }
    }
}

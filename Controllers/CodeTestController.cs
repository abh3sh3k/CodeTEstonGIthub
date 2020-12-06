using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeTEst.Models;

namespace CodeTEst.Controllers
{
    public class CodeTestController : ApiController
    {
        public HttpResponseMessage GetEmployee()
        {
            //Similarly we can make the list of managers and supervisors
            List<Employee> employeeList = new List<Employee>();
            using (CodeTestEmployeeEntities1 dc = new CodeTestEmployeeEntities1())
            {
                employeeList = dc.Employees.OrderBy(a => a.FirstName).ToList();
                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, employeeList);
                return response;
            }
        }
        //we can create a new worker model and pass it as a parameter here
        public IHttpActionResult PostNewWorker()
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new CodeTestEmployeeEntities1())
            {
                ctx.Employees1.Add(new Employee1()
                {
                    EmployeeID = 21,
                    FirstName = "Raj",
                    LastName = "chanda"
                });

                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}

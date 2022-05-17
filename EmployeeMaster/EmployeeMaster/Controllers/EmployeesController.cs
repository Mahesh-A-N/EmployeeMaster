using EmployeeMaster.EmployeeData;
using EmployeeMaster.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeMaster.Controllers
{
  
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        [HttpGet]
        [Route("api/GetAll/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/Get[controller]/EmployeeERPId={EmployeeERPId}")]
        public IActionResult GetEmployee([FromRoute] string EmployeeERPId)
        {
            var EmployeeData = _employeeData.GetEmployee(EmployeeERPId);
            if(EmployeeData != null)
            {
                return Ok(EmployeeData);
            }
            else
            {
                return NotFound($"Empoloyee Not Found : {EmployeeERPId}");
            }          
        }

        [HttpPost]
        [Route("api/Add/[controller]")]
        public IActionResult AddEmployee([FromBody]  Employee employee)
        {
            var EmployeeData = _employeeData.GetEmployee(employee.EmployeeERPId);
            if (EmployeeData == null)
            {
                _employeeData.AddEmployee(employee);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.EmployeeERPId, employee);
            }
            else
            {
                return NotFound($"Empoloyee With Same ERPId Already Available : {employee.EmployeeERPId}");
            }

        }
        [HttpPatch]
        [Route("api/Edit/[controller]")]
        public IActionResult EditEmployee([FromBody] Employee employee)
        {
          
            var EmployeeData = _employeeData.GetEmployee(employee.EmployeeERPId);
            if (EmployeeData != null)
            {
          
                _employeeData.EditEmployee(employee);
                return Ok(employee);
            }
            else
            {
                return NotFound($"Empoloyee Not Found : {employee.EmployeeERPId}");
            }
        }
        [HttpDelete]
        [Route("api/Delete/[controller]/EmployeeERPId={EmployeeERPId}")]
        public IActionResult DeleteEmployee([FromRoute] string EmployeeERPId)
        {
            var EmployeeData = _employeeData.GetEmployee(EmployeeERPId);
            if (EmployeeData != null)
            {
                _employeeData.DeleteEmployee(EmployeeData);
                return Ok($"Empoloyee Deleted Successfully : {EmployeeERPId}");
            }
            else
            {
                return NotFound($"Empoloyee Not Found : {EmployeeERPId}");
            }          
        }



    }
}

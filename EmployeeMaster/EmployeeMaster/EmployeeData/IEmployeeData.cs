using EmployeeMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaster.EmployeeData
{
    public interface IEmployeeData
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(string EmployeeERPId);
        public Employee AddEmployee(Employee employee);
        public Employee EditEmployee(Employee employee);
        public Employee DeleteEmployee(Employee employee);
    }
}

using EmployeeMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaster.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private readonly EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public List<Employee> GetEmployees()
        {
            return _employeeContext.employees.ToList();
        }
        public Employee GetEmployee(string EmployeeERPId)
        {
            var employee = _employeeContext.employees.Find(EmployeeERPId);
            return employee;
        }
        public Employee AddEmployee(Employee employee)
        {
            var EmployeeData = _employeeContext.employees.Find(employee.EmployeeERPId);
            if (EmployeeData == null)
            {
                employee.EmployeeGuid = Convert.ToString(Guid.NewGuid());
                _employeeContext.employees.Add(employee);
                _employeeContext.SaveChanges();
                
            }
            return employee;


        }
        public Employee EditEmployee(Employee employee)
        {
            var ValidateERPId = _employeeContext.employees.Find(employee.EmployeeERPId);

            if (ValidateERPId!=null)
            {
                ValidateERPId.Name = employee.Name;
                employee.EmployeeGuid = ValidateERPId.EmployeeGuid;
                _employeeContext.employees.Update(ValidateERPId);
                _employeeContext.SaveChanges();
               
            }
            return employee;
        }
        public Employee DeleteEmployee(Employee employee)
        {
            _employeeContext.employees.Remove(employee);
            _employeeContext.SaveChanges();
            return employee;
        }






    }


}

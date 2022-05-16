using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaster.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [MaxLength(10,ErrorMessage = "EmployeeERPId Can only be 10 Characters ")]
        public string EmployeeERPId { get; set; }
        public string EmployeeGuid { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "EmployeeERPId Can only be 50 Characters ")]
        public string Name { get; set; }
    }
}

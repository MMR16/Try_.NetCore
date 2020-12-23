using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_App.Models
{
    public class Employee
    {
        [Column(Order =0)]
        public int Id { get; set; }
        [Column(Order = 2)]
        public int Age { get; set; }
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 3)]
        public int? Salary { get; set; }

        [ForeignKey("Department")]
        [Column(Order = 4)]
        public int DeptId { get; set; }

        public virtual  Department Department { get; set; }
    }
}

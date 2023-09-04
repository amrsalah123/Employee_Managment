using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
   public class employee
    {

        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string name { get; set; }

        [Required]
        [DisplayName("Employee Salary")]
        public float salary { get; set; }
        [Required]
        [DisplayName("Department")]
        public string department { get; set; }
    }
}

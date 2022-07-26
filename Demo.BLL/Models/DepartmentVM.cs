using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Demo.DAL.Entity;

namespace Demo.BLL.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        [MaxLength(50 , ErrorMessage = "Max Len 50")]
        [MinLength(3,ErrorMessage = "Min Len 3")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Enter Department Code")]
        public string DepartmentCode { get; set; }


        public ICollection<Employee> Employee { get; set; }

    }
}

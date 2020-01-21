using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLabPractice.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace MvcPractice.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Can not be Empty")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [Display(Name = "Roll No:")]
        public string RollNo { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
       
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Student> Students { get; set; }
        public List<SelectListItem> DepartmentSelectListItems { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using MvcLabPractice.Model.Model;
using  System.Web.Mvc;
using Type = MvcLabPractice.Model.Model.Type;

namespace MvcPractice.Models
{
    public class MemberViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Can not be Empty")]
        [StringLength(5,MinimumLength =5, ErrorMessage = "Lenght must 5")]
        [Display(Name = "Code:")]
        public string Code { set; get; }
        [Required(ErrorMessage = "Can not be Empty")]
        [Display(Name = "Name:")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Can not be Empty")]
        [Display(Name = "Email:")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Can not be Empty")]
        [Display(Name = "ContactNo:")]
        public string ContactNo { set; get; }
        
        public string TypeId { set; get; }
        
        public Type Type { get; set; }
        public List<Member> Members{ get; set; }
        public List<SelectListItem> MemberSelectListItems { get; set; }
        public List<SelectListItem> TypeSelectListItems{ get; set; }

    }
}
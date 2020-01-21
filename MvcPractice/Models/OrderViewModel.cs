using System;
using System.Collections.Generic;
using System.Linq;
using  System.ComponentModel.DataAnnotations;
using System.Web;
using MvcLabPractice.Model.Model;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Type = MvcLabPractice.Model.Model.Type;

namespace MvcPractice.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int FoodItemId { get; set; }
        public  int MemberItemId { get; set; }
        public int UnitPrice { get; set; }
        public int Qauntity { get; set; }
        public DateTime Date { get; set; }
        public FoodItem FoodItem { get; set; }
        public Member Member { get; set; }
        public Type Type { get; set; }
        public List<Member> Members { get; set; }
        public List<SelectListItem> CodeSelectListItems { get; set; }
        public List<Order> Orders { get; set; }
        public List<SelectListItem> FoodItemSelectListItems { get; set; }
    }
}
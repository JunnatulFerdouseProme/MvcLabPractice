using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MvcLabPractice.BLL.BLL;
using MvcLabPractice.Model.Model;
using MvcPractice.Models;

namespace MvcPractice.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        MemberManager _memberManager = new MemberManager();
        TypeManger _typeManger = new TypeManger();
        OrderManager _orderManager=new OrderManager();
        FoodItemManager _foodItemManager=new FoodItemManager();
        public ActionResult Add()
        {
            MemberViewModel _memberViewModel = new MemberViewModel();
            OrderViewModel _orderViewModel = new OrderViewModel();
           

            _memberViewModel.MemberSelectListItems = _memberManager.GetAll()
                                                             .Select(c => new SelectListItem()
                                                               {
                                                                      Value = c.Code,
                                                                      Text = c.Code
                                                                  }).ToList();

            _orderViewModel.FoodItemSelectListItems = _foodItemManager
               .GetAll()
               .Select(c => new SelectListItem()
               {
                   Value = c.Id.ToString(),
                   Text = c.Name
               }).ToList();

            ViewBag.MemberItemId = _memberViewModel.MemberSelectListItems;

            return View(_orderViewModel);
        }

        [HttpPost]
        public ActionResult Add(OrderViewModel _orderViewModel)
        {
            string message = "";

            //Student student = new Student();
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;
            if (ModelState.IsValid)
            {
                Order order = Mapper.Map<Order>(_orderViewModel);

                if (_orderManager.Add(order))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "MOdelState Failed";
            }

            ViewBag.Message = message;
            MemberViewModel _memberViewModel = new MemberViewModel();
         

            _memberViewModel.MemberSelectListItems = _memberManager.GetAll()
                                                             .Select(c => new SelectListItem()
                                                             {
                                                                 Value = c.Code,
                                                                 Text = c.Code
                                                             }).ToList();
            _orderViewModel.FoodItemSelectListItems = _foodItemManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            ViewBag.MemberItemId = _memberViewModel.MemberSelectListItems;
            return View(_orderViewModel);

        }
        public JsonResult GetMemberDetailsByMemberId(int? memberId)
        {
            var memberDetails = _memberManager.GetAll().Where(c => c.Id == memberId).ToList();
            //var products = from p in productList select (new { p.Code });
            return Json(memberDetails, JsonRequestBehavior.AllowGet);
        }
    }
}
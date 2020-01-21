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
            _orderViewModel.Orders = _orderManager.GetAll();
           _orderViewModel.Members = _memberManager.GetAll();

          _orderViewModel.CodeSelectListItems=_memberManager.GetAll()
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
            _orderViewModel.Orders = _orderManager.GetAll();
            _orderViewModel.Members = _memberManager.GetAll();

            _orderViewModel.CodeSelectListItems = _memberManager.GetAll()
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

      

            return View(_orderViewModel);

        }
        public JsonResult GetMemberNameById(int ? memberId)
        {
            var memberList = _memberManager.GetAll().Where(c => c.Id == memberId).ToList();
            var name = memberList.Select(c => new { c.Name }).ToList();
            return Json(name, JsonRequestBehavior.AllowGet);
        }
    }
}
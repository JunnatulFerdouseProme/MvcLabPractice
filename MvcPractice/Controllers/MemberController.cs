using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MvcLabPractice.Model.Model;
using  MvcLabPractice.BLL.BLL;
using  MvcLabPractice.Repository.Repository;
using  System.Web.Mvc;
using MvcPractice.Models;

namespace MvcPractice.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        MemberManager _memberManager=new MemberManager();
        TypeManger _typeManger=new TypeManger();
        public ActionResult Add()
        {
            MemberViewModel _memberViewModel=new MemberViewModel();
            _memberViewModel.Members = _memberManager.GetAll();

            _memberViewModel.TypeSelectListItems = _typeManger
                                     .GetAll()
                                     .Select(c => new SelectListItem()
                                     {
                                         Value = c.Id.ToString(),
                                         Text = c.Name
                                     }).ToList();

            return View(_memberViewModel);
        }

        [HttpPost]
        public ActionResult Add(MemberViewModel memberViewModel)
        {
            string message = "";

            //Student student = new Student();
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;
            if (ModelState.IsValid) { 
              Member member = Mapper.Map<Member>(memberViewModel);

                if (_memberManager.Add(member))
                {
                    message = "Saved";
                    ModelState.Clear();
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "ModelSate Falied";
            }


            ViewBag.Message = message;
            memberViewModel.Members = _memberManager.GetAll();

            memberViewModel.TypeSelectListItems = _typeManger
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
           
            return View(memberViewModel);
        }
        public JsonResult IsRollNoExits(string code)
        {
            bool isExits = false;
            var studentList = _memberManager.GetAll().Where(c => c.Code== code).ToList();

            if (studentList.Count() > 0)
            {
                isExits = true;
            }

            return Json(isExits, JsonRequestBehavior.AllowGet);
        }

    }
    
}
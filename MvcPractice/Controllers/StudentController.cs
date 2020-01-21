using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLabPractice.BLL.BLL;
using MvcPractice.Models;
using MvcLabPractice.Model.Model;
using AutoMapper;
using System.Web.Mvc;

namespace MvcPractice.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();
        DepartmentManager _departmentManager = new DepartmentManager();
        //public string Add(string rollNo, string name, string address, int? age, int? departmentId)

        [HttpGet]
        public ActionResult Add()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll();

            studentViewModel.DepartmentSelectListItems = _departmentManager
                                     .GetAll()
                                     .Select(c => new SelectListItem()
                                     {
                                         Value = c.Id.ToString(),
                                         Text = c.Name
                                     }).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel studentViewModel)
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
                Student student = Mapper.Map<Student>(studentViewModel);

                if (_studentManager.Add(student))
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
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(studentViewModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll();

            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(studentViewModel);

        }

        [HttpPost]
        public ActionResult Search(DateTime? startdate,DateTime? enddate)
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            var students = _studentManager.GetAll();
            if(studentViewModel.Date!= null)
            {
                students = students.Where(c => c.Date > startdate && c.Date < enddate).ToList();
            }
          

            studentViewModel.Students = students;
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(studentViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = _studentManager.GetById(id);

            StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);

            studentViewModel.Students = _studentManager.GetAll();

            studentViewModel.DepartmentSelectListItems = _departmentManager
                                     .GetAll()
                                     .Select(c => new SelectListItem()
                                     {
                                         Value = c.Id.ToString(),
                                         Text = c.Name
                                     }).ToList();

            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
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
                Student student = Mapper.Map<Student>(studentViewModel);

                if (_studentManager.Update(student))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            studentViewModel.Students = _studentManager.GetAll();
            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(studentViewModel);
        }

        public ActionResult StudentDetails()
        {
            StudentViewModel studentViewModel = new StudentViewModel();


            studentViewModel.DepartmentSelectListItems = _departmentManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            ViewBag.Department = studentViewModel.DepartmentSelectListItems;
            return View(studentViewModel);
        }

        //Cascade Dropdown
        public JsonResult GetStudentByDepartmentId(int departmentId)
        {
            var studentlList = _studentManager.GetAll().Where(c => c.DepartmentId == departmentId).ToList();

            var students = from s in studentlList select (new { s.Id, s.Name });
            return Json(students, JsonRequestBehavior.AllowGet);
        }
        //Unique Test
        public JsonResult IsRollNoExits(string rollNo)
        {
            bool isExits = false;
            var studentList = _studentManager.GetAll().Where(c => c.RollNo == rollNo).ToList();

            if (studentList.Count() > 0)
            {
                isExits = true;
            }

            return Json(isExits, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsNameExits(string name)
        {
            bool isExits = false;
            var studentList = _studentManager.GetAll().Where(c => c.Name == name).ToList();

            if (studentList.Count() > 0)
            {
                isExits = true;
            }

            return Json(isExits, JsonRequestBehavior.AllowGet);
        }

        //StudentDetails
        public ActionResult GetStudentById(int id)
        {
            //var student = _studentManager.GetById(id);
            //StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(student);

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Students = _studentManager.GetAll().Where(c => c.Id == id).ToList();
            return PartialView("Student/_StudentDetails", studentViewModel);
        }
    }
}
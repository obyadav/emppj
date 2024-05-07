using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emppj.Controllers
{
    public class HomeController : Controller
    {
        EmpEntity _context = new EmpEntity();
        public ActionResult Index()
        {
            var listofData = _context.Employees.ToList();
            return View(listofData);
        }
       

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Employees.Where(x => x.employeeId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee Model)
        {
            var data = _context.Employees.Where(x => x.employeeId == Model.employeeId).FirstOrDefault();
            if (data != null)
            {
                data.FirstName = Model.FirstName;
                data.LastName = Model.LastName;
                data.Email = Model.Email;
                data.LastName = Model.Location;
                data.DateOfBirth = Model.DateOfBirth;
                _context.SaveChanges();
                ViewBag.Messsage = "Record Delete Successfully";

            }

            return RedirectToAction("index");
        }


        public ActionResult Delete(int id)
        {
            var data = _context.Employees.Where(x => x.employeeId == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }


        public ActionResult SalaryIndex()
        {
            var listOfSalaries = _context.Salaries.ToList();
            return View(listOfSalaries);
        }

        [HttpGet]
        public ActionResult SalAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalAdd(Salary model)
        {
            _context.Salaries.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View("SalaryIndex");
        }

        [HttpGet]
        public ActionResult SalEdit(int id)
        {
            var data = _context.Salaries.Where(x => x.payrollitem == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult SalEdit(Salary Model)
        {
            var data = _context.Salaries.Where(x => x.payrollitem == Model.payrollitem).FirstOrDefault();
            if (data != null)
            {
                data.itemtype = Model.itemtype;

                data.Name = Model.Name;
                data.value = Model.value;
                
                _context.SaveChanges();
                ViewBag.Messsage = "Record Update Successfully";

            }

            return RedirectToAction("SalaryIndex");
        }


        public ActionResult SalDelete(int id)
        {
            var data = _context.Salaries.Where(x => x.payrollitem == id).FirstOrDefault();
            _context.Salaries.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("Salaryindex");
        }


    }
}

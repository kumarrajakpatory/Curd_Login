using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Curd_Login.Models;

namespace Curd_Login.Controllers
{
    public class EmployeeController : Controller
    {
         DbServiceContext db = new DbServiceContext();
        // GET: Employee
        public ActionResult Index()
        {

            return View(db.tbl_emp.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            db.tbl_emp.Add(emp);
            int a =  db.SaveChanges();
            if (a > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.SubmitMsg = ("<script> alert('something went to wrong ')</script>");
            }

            return View();
        }
        public ActionResult Edit(int id)
        {
           var a = db.tbl_emp.Where(model => model.ID == id).FirstOrDefault();
            return View(a);
        }
        [HttpPost]
        public ActionResult Edit( Employee em)
        {
            db.Entry(em).State =EntityState.Modified;
            int a = db.SaveChanges();
            //var a = db.tbl_emp.Where(model => model.ID == id).FirstOrDefault();
            if (a > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.EditMsg = ("<script> alert('something went to wrong ')</script>");
            }
            return View(a);
        }
        public ActionResult Delete(int id)
        {
            var a = db.tbl_emp.Where(model => model.ID == id).FirstOrDefault();
            return View(a);
        }
        [HttpPost]
        public ActionResult Delete(Employee em)
        {
            db.Entry(em).State = EntityState.Deleted;
            int a = db.SaveChanges();
            //var a = db.tbl_emp.Where(model => model.ID == id).FirstOrDefault();
            if (a > 0)
            {
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DeleteMsg = ("<script> alert('something went to wrong ')</script>");
            }
            return View(a);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee emp)
        {
            //db.tbl_emp.Add(emp);
            //int a = db.SaveChanges();
            var row = db.tbl_emp.Where(model => model.Email == emp.Email && model.Password == emp.Password).FirstOrDefault();
           
            if (row != null)
            {
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.LoginMsg = ("<script> alert('something went to wrong ')</script>");
                ModelState.Clear();
            }

            return View();
        }
        public ActionResult Welcome ()
        {
            return View(db.tbl_emp.ToList());
        }
    }
}
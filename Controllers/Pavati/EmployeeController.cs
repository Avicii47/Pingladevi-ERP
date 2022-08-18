using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;

namespace Pingladevi.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeIndex()
        {
            return View();
        }
        public ActionResult EmployeeListIndex()
        {
            return View();
        }
        public ActionResult SaveEmployee(Employeemodel model)
        {
            try
            {
                return Json(new { message = (new Employeemodel().SaveEmployee(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { model = Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetEmployeeList()
        {
            try
            {
                return Json(new { model = (new Employeemodel().GetEmployeeList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
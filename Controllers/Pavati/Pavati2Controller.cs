using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;

namespace Pingladevi.Controllers.Pavati
{
    public class Pavati2Controller : Controller
    {
        // GET: Pavati2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pavati2ListIndex()
        {
            return View();
        }
       
        public ActionResult SavePavati(Pavati2model model)
        {
            try
            {
                return Json(new { message = (new Pavati2model().SavePavati(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { model = Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DetailData(int Id)
        {
            try
            {
                return Json(new { model = (new Pavati2model().DetailData(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPavati2List(String FromDate, String ToDate)
        {
            try
            {
                return Json(new { model = (new Pavati2model().GetPavati2List( FromDate,ToDate)) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}

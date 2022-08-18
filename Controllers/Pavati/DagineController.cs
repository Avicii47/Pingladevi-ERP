using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;

namespace Pingladevi.Controllers
{
    public class DagineController : Controller
    {
        // GET: Dagine
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveData(DagineMode model)
        {
            try
            {
                return Json(new { model = (new DagineMode().Savedata(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        //public ActionResult DetailData(int Id)
        //{
        //    try
        //    {
        //        return Json(new { model = (new DagineMode().DetailData(Id)) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
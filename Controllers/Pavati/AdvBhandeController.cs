using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;
using System.IO;


namespace Pingladevi.Controllers
{
    public class AdvBhandeController : Controller
    {
        // GET: AdvBhande
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveData(AdvBhandePavatiModel model)
        {
            try
            {
                return Json(new { model = (new AdvBhandePavatiModel().Savedata(model)) },
                    JsonRequestBehavior.AllowGet);
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
                return Json(new { model = (new AdvBhandePavatiModel().DetailData(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
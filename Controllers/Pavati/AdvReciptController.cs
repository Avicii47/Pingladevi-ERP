using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;
using System.IO;


namespace Pingladevi.Controllers
{
    public class AdvReciptController : Controller
    {
        // GET: AdvRecipt
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult SaveData(AdvReciptModel model)
        {
            try
            {
                return Json(new { model = (new AdvReciptModel().Savedata(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult DetailData(int Id)
        {
            try
            {
                return Json(new { model = (new AdvReciptModel().DetailData(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
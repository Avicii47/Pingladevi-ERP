using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;

namespace Pingladevi
{
    public class DaginePavatiController : Controller
    {
        // GET: DaginePavati
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult SaveData(DaginePavatiModel model)
        //{
        //    try
        //    {
        //        return Json(new { model = (new DaginePavatiModel().Savedata(model)) },
        //            JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }

        //}
        public ActionResult SaveData(DaginePavatiModel model)
        {
            try
            {
                return Json(new { model = (new DaginePavatiModel().SaveData(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
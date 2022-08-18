using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;

namespace Pingladevi.Controllers
{
    public class AddItemController : Controller
    {
        // GET: AddItem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveData(AddItemModel model)
        {
            try
            {
                return Json(new { model = (new AddItemModel().Savedata(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetList()
        {
            try
            {
                return Json(new { model = (new AddItemModel().GetList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message });
            }
        }
        public ActionResult deleteItem(int Id)
        {
            try
            {
                return Json(new { model = (new AddItemModel().deleteItem(Id)) },
                JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetEditData(int ID)
        {
            try
            {
                return Json(new { model = (new AddItemModel().EditData(ID)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetItemDDLList()
        {
            try
            {
                return Json(new { model = (new AddItemModel().GetItemDDLList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new {ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;
using Pingladevi.Data;

namespace Pingladevi.Controllers
{
    public class RentPavtiController : Controller
    {
        // GET: RentPavti
        public ActionResult Index()
        {
            PingladeviEntities sd = new PingladeviEntities();
            ViewBag.Item = new SelectList(sd.TblAddItems, "ItemNo", "Name");
            return View();
        }
        public ActionResult PrintRecipt()
        {
            return View();
        }

        public ActionResult SaveData(RentPavatiModel model)
        {
            try
            {
                return Json(new { model = (new RentPavatiModel().Savedata(model)) },
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
                return Json(new { model = (new RentPavatiModel().DetailData(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SaveInvoice(InvoiceModel model)
        {
            try
            {
                return Json(new { model = (new InvoiceModel().SaveInvoice(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult SaveFinalInvoice(InvoiceModel model)
        {
            try
            {
                return Json(new { model = (new InvoiceModel().SaveFinalInvoice(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetList(int ReciptNo)
        {
            try
            {
                return Json(new { model = (new InvoiceModel().GetList(ReciptNo)) }, JsonRequestBehavior.AllowGet);
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
                return Json(new { model = (new InvoiceModel().deleteItem(Id)) },
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
                return Json(new { model = (new InvoiceModel().EditData(ID)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult Linqlist()
        {
            try
            {
                return Json(new { model = (new FinalRentRecipt().usinglinq()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
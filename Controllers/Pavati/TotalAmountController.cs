using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pingladevi.Models;

namespace Pingladevi.Controllers.Pavati
{
    public class TotalAmountController : Controller
    {
        // GET: TotalAmount
        public ActionResult Index()
        {
            List<TotalAmountModel> data = new List<TotalAmountModel>();
            //Random rnd = new Random();
            for (int i = 1; i <= 1; i++)
            {
                data.Add(new TotalAmountModel() { Donar_Name = "Donar Name" + i.ToString()});
            }
            return View(data);
        }
        
    }
}
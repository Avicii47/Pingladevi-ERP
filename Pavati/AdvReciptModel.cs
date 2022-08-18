using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pingladevi.Data;
using System.IO;
using System.Data;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace Pingladevi.Models
{
    public class AdvReciptModel
    {
        public int ReciptNo { get; set; }
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public string DateString { get; set; }

        public string MobileNo { get; set; }
        public System.DateTime StartDate { get; set; }
        public string StartDateString { get; set; }
        public System.DateTime Enddate { get; set; }
        public string EnddateString { get; set; }

        public string Total { get; set; }
        public string Advance { get; set; }
        public string Remaining { get; set; }

        public string Savedata(AdvReciptModel model)
        {
            string message = "";

            PingladeviEntities db = new PingladeviEntities();
            //var getCatData = db.TblAdvanceRecipts.Where(p => p.ReciptNo == model.ReciptNo).FirstOrDefault();
            //if (getCatData == null)
            { //{
                var savedata = new TblAdvanceRecipt()
                {
                    ReciptNo = model.ReciptNo,
                    Name = model.Name,
                    Date = model.Date,
                    MobileNo = model.MobileNo,
                    StartDate = model.StartDate,
                    Enddate = model.Enddate,
                    Total = model.Total,
                    Advance = model.Advance,
                    Remaining = model.Remaining,
                };
                db.TblAdvanceRecipts.Add(savedata);
                db.SaveChanges();
                message = savedata.ReciptNo.ToString();
            }

            return message;
        }
        public AdvReciptModel DetailData(int Id)
        {
            string msg = "";
            AdvReciptModel model = new AdvReciptModel();
            PingladeviEntities Db = new PingladeviEntities();
            var editData = Db.TblAdvanceRecipts.Where(p => p.ReciptNo == Id).FirstOrDefault();
            if (editData != null)
            {
                model.ReciptNo = editData.ReciptNo;
                model.Name = editData.Name;
                model.DateString = editData.Date.ToString("MM/dd/yyyy");
                model.MobileNo = editData.MobileNo;
                model.StartDateString = editData.StartDate.ToString("MM/dd/yyyy");
                model.EnddateString = editData.Enddate.ToString("MM/dd/yyyy");
                model.Total = editData.Total;
                model.Advance = editData.Advance;
                model.Remaining = editData.Remaining;
            }
            msg = "";
            return model;
        }
    }

}
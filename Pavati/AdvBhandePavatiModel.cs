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
    public class AdvBhandePavatiModel
    {
        public int ReciptNo { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public System.DateTime EventDate { get; set; }
        public string EventDateString { get; set; }
        public string Mob { get; set; }
        public string Items { get; set; }
        public decimal Rent { get; set; }
        public decimal Total { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string DateString { get; set; }

        public string Savedata(AdvBhandePavatiModel model)
        {
            string message = "";

            PingladeviEntities db = new PingladeviEntities();
            { 
                var savedata = new TblAdvBhande()
                {
                    Date = model.Date,
                    ReciptNo = model.ReciptNo,
                    Name = model.Name,
                    City = model.City,
                    EventDate = model.EventDate,
                    Mob = model.Mob,
                    Items = model.Items,
                    Rent = model.Rent,
                    Total = model.Total,
                };
                db.TblAdvBhandes.Add(savedata);
                db.SaveChanges();
                message = savedata.ReciptNo.ToString();
            }

            return message;
        }
        public AdvBhandePavatiModel DetailData(int Id)
        {
            string msg = "";
            AdvBhandePavatiModel model = new AdvBhandePavatiModel();
            PingladeviEntities Db = new PingladeviEntities();
            var editData = Db.TblAdvBhandes.Where(p => p.ReciptNo == Id).FirstOrDefault();
            if (editData != null)
            {
                model.ReciptNo = editData.ReciptNo;
                model.Name = editData.Name;
                DateTime? date = editData.Date;
                model.Mob = editData.Mob;
                model.EventDateString = editData.EventDate.ToString("MM/dd/yyyy");
                model.Total = editData.Total;
                model.Rent = editData.Rent;
                model.Items = editData.Items;
            }
            msg = "";
            return model;
        }
    }
}
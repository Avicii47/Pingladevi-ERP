using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pingladevi.Data;

namespace Pingladevi.Models
{
    public class DagineMode
    {
        public int ReciptNo { get; set; }
        public System.DateTime Date { get; set; }
        public string DateString{get; set;}
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public decimal Weight { get; set; }
        public decimal PerGramRate { get; set; }
        public decimal Total { get; set; }
        public string Savedata(DagineMode model)
        {
            string message = "";

            PingladeviEntities db = new PingladeviEntities();
            {
                var savedata = new TblDagine()
                {
                    Date = model.Date,
                    Name = model.Name,
                    City = model.City,
                    Mobile = model.Mobile,
                    Item = model.Item,
                    Quantity = model.Quantity,
                    Weight = model.Weight,
                    PerGramRate = model.PerGramRate,
                    Total = model.Total, 
                };
                db.TblDagines.Add(savedata);
                db.SaveChanges();
                message = savedata.ReciptNo.ToString();
            }
            return message;
        }
        //public DagineMode DetailData(int Id)
        //{
        //    string msg = "";
        //    DagineMode model = new DagineMode();
        //    PingladeviEntities Db = new PingladeviEntities();
        //    var editData = Db.TblDagines.Where(p => p.ReciptNo == Id).FirstOrDefault();
        //    if (editData != null)
        //    {
        //        model.ReciptNo = editData.ReciptNo;
        //        model.Name = editData.Name;
        //        model.DateString = editData.Date.ToString("MM/dd/yyyy");
        //        model.City = editData.City;
        //        model.Mobile = editData.Mobile;
        //        model.Item = editData.Item;
        //        model.Quantity = editData.Quantity;
        //        model.Weight = editData.Weight;
        //        model.PerGramRate = editData.PerGramRate;
        //        model.Total = editData.Total;
        //    }
        //    msg = "";
        //    return model;
        //}
    }
}
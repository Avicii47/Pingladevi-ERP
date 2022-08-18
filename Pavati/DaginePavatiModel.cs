using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pingladevi.Data;

namespace Pingladevi.Models
{
    public class DaginePavatiModel
    {
        public int ReciptNo { get; set; }
        public System.DateTime Date { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public decimal Weight { get; set; }
        public decimal PerGramRate { get; set; }
        public decimal Total { get; set; }
        public string SaveData(TblDagine model)
        {
            string message = "";
            PingladeviEntities db = new PingladeviEntities();
            {
                var savedata = new TblDagine()
                {
                    /*ReciptNo = model.ReciptNo*/
                    Date = model.Date,
                    Name = model.Name,
                    City = model.City,
                    Address = model.Address,
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
        }
        //public List<DaginePavatiModel> GetList()
        //{
        //    PingladeviEntities db = new PingladeviEntities();
        //    List<DaginePavatiModel> LstCategory = new List<DaginePavatiModel>();
        //    var listsd = db.TblDagines.ToList();
        //    if (listsd != null)
        //    {
        //        foreach (var Category in listsd)
        //        {
        //            LstCategory.Add(new DaginePavatiModel()
        //            {
        //                ReciptNo = Category.ReciptNo,
        //                Date = Category.Date,
        //                Name = Category.Name,
        //                City = Category.City,
        //                Address = Category.Address,
        //                Mobile = Category.Mobile,
        //                Item = Category.Item,
        //                Quantity = Category.Quantity,
        //                Weight = Category.Weight,
        //                PerGramRate = Category.PerGramRate,
        //                Total = Category.Total,

        //            });
        //        }
        //    }
        //    return LstCategory;
        //}
    }

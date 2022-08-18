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
    public class RentPavatiModel
    {
        public int ReciptNo { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public string StartTimeString { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public string EndTimeString { get; set; }
        public System.DateTime Date { get; set; }
        public string DateString { get; set; }
        public string ItemNo { get; set; }



        public string Savedata(RentPavatiModel model)
        {
            string message = "";

            PingladeviEntities db = new PingladeviEntities();
            //var getCatData = db.TblAdvanceRecipts.Where(p => p.ReciptNo == model.ReciptNo).FirstOrDefault();
            //if (getCatData == null)
            {
                var savedata = new TblRent()
                {
                    ReciptNo = model.ReciptNo,
                    Name = model.Name,
                    Date = model.Date,
                    City = model.City,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,

                };
                db.TblRents.Add(savedata);
                db.SaveChanges();
                message = savedata.ReciptNo.ToString();
            }

            return message;
        }

        public RentPavatiModel DetailData(int Id)
        {
            string msg = "";
            RentPavatiModel model = new RentPavatiModel();
            PingladeviEntities Db = new PingladeviEntities();
            var editData = Db.TblRents.Where(p => p.ReciptNo == Id).FirstOrDefault();
            if (editData != null)
            {
                model.ReciptNo = editData.ReciptNo;
                model.Name = editData.Name;
                model.City = editData.City;
                model.DateString = editData.Date.ToString("MM/dd/yyyy");
                model.StartTime = editData.StartTime;
                model.EndTime = editData.EndTime;
            }
            msg = "";
            return model;
        }

    }



    public class InvoiceModel
    {
        public int Id { get; set; }
        public int ReciptNo { get; set; }
        //public string ItemNo { get; set; }
        public decimal PerDayRate { get; set; }
        public string Item { get; set; }
        public string TotalItem { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Advance { get; set; }
        public decimal Balance { get; set; }
        public string SaveInvoice(InvoiceModel model)
        {
            string message = "";

            PingladeviEntities db = new PingladeviEntities();
            var getCatData = db.tblInvoices.Where(p => p.Id == model.Id).FirstOrDefault();
            if (getCatData == null)
            {
                var saveinvoice = new tblInvoice()
                {
                    Id = model.Id,
                    ReciptNo = model.ReciptNo,
                    Item = model.Item,
                    PerDayRate = model.PerDayRate,
                    TotalItem = model.TotalItem,
                    TotalPrice = model.TotalPrice,

                };
                db.tblInvoices.Add(saveinvoice);
                db.SaveChanges();
                message = model.ReciptNo.ToString();
                return message;
            }
            else
            {
                getCatData.Item = model.Item;
                getCatData.ReciptNo = model.ReciptNo;
                getCatData.PerDayRate = model.PerDayRate;
                getCatData.TotalItem = model.TotalItem;
                getCatData.TotalPrice = model.TotalPrice;

                db.SaveChanges();
                message = "Update Succesfully";
                return message;
            }

        }
        public string SaveFinalInvoice(InvoiceModel model)
        {
            string message = "";
            PingladeviEntities db = new PingladeviEntities();
            /*var Itemssd = db.TblTotalAmounts.Where(p => p.Id == Id).FirstOrDefault();*/

            {
                var savedata = new TblTotalAmount()
                {
                    ReciptNo = model.ReciptNo,
                    GrandTotal = model.GrandTotal,
                    Advance = model.Advance,
                    Balance = model.Balance,
                };
                db.TblTotalAmounts.Add(savedata);
                db.SaveChanges();
                message = savedata.ReciptNo.ToString();
            }

            return message;
        }
        public List<InvoiceModel> GetList(int ReciptNo)
        {
            PingladeviEntities db = new PingladeviEntities();
            List<InvoiceModel> LstCategory = new List<InvoiceModel>();
            var Itemssd = db.tblInvoices.Where(p => p.ReciptNo == ReciptNo).ToList();

            if (Itemssd != null)
            {
                foreach (var Category in Itemssd)
                {
                    LstCategory.Add(new InvoiceModel()
                    {
                        Id = Category.Id,
                        Item = Category.Item,
                        ReciptNo = Category.ReciptNo,
                        PerDayRate = Category.PerDayRate,
                        TotalItem = Category.TotalItem,
                        TotalPrice = Category.TotalPrice,
                    });

                }
            }
            return LstCategory;
        }
        public string deleteItem(int id)
        {
            string Message = "";
            PingladeviEntities Db = new PingladeviEntities();
            var deleteRecord = Db.tblInvoices.Where(p => p.Id == id).FirstOrDefault();
            if (deleteRecord != null)
            {
                Db.tblInvoices.Remove(deleteRecord);
            };
            Db.SaveChanges();
            Message = "Item Deleted Successfully";
            return Message;
        }
        public InvoiceModel EditData(int id)
        {
            string message = "";
            InvoiceModel model = new InvoiceModel();
            PingladeviEntities Db = new PingladeviEntities();
            var editData = Db.tblInvoices.Where(p => p.ReciptNo == id).FirstOrDefault();

            if (editData != null)
            {
                model.Id = editData.Id;
                model.Item = editData.Item;
                model.PerDayRate = editData.PerDayRate;
                model.TotalItem = editData.TotalItem;
                model.TotalPrice = editData.TotalPrice;
            }
            message = "Record Edit Successfully";
            return model;
        }

    }


    public class FinalRentRecipt
    {
        public int ReciptNo { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public string StartTimeString { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public string EndTimeString { get; set; }
        public System.DateTime Date { get; set; }
        public string DateString { get; set; }
        public string ItemNo { get; set; }
        public int Id { get; set; }
        public decimal PerDayRate { get; set; }
        public string Item { get; set; }
        public string TotalItem { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Advance { get; set; }
        public decimal Balance { get; set; }


        public List<FinalRentRecipt> usinglinq()
        {
            PingladeviEntities db = new PingladeviEntities();
            List<FinalRentRecipt> lstPro = new List<FinalRentRecipt>();
            var LinqList = from rent in db.TblRents
                           join invoice in db.tblInvoices on rent.ReciptNo equals invoice.ReciptNo
                           //from rent1 in db.TblRents
                           join amt in db.TblTotalAmounts on rent.ReciptNo equals amt.ReciptNo
                           select new
                           {
                               rent.ReciptNo,
                               rent.Name,
                               rent.City,
                               rent.StartTime,
                               rent.EndTime,
                               rent.Date,
                               invoice.Item,
                               invoice.PerDayRate,
                               invoice.TotalItem,
                               invoice.TotalPrice,
                               amt.GrandTotal,
                               amt.Advance,
                               amt.Balance
                           };
            if (LinqList != null)
            {
                foreach (var AddProduct in LinqList)
                {
                    lstPro.Add(new FinalRentRecipt()
                    {
                        ReciptNo = AddProduct.ReciptNo,
                        Name = AddProduct.Name,
                        City = AddProduct.City,
                        StartTime = AddProduct.StartTime,
                        EndTime = AddProduct.EndTime,
                        Date = AddProduct.Date,
                        Item = AddProduct.Item,
                        PerDayRate = AddProduct.PerDayRate,
                        TotalItem = AddProduct.TotalItem,
                        TotalPrice = AddProduct.TotalPrice,
                        GrandTotal = AddProduct.GrandTotal,
                        Advance = AddProduct.Advance,
                        Balance = AddProduct.Balance,

                    });
                }
            }
            return lstPro;
        }
    }
}
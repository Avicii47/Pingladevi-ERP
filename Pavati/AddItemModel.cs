using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pingladevi.Data;

namespace Pingladevi.Models
{
    public class AddItemModel
    {
        public int ItemNo { get; set; }
        public string Name { get; set; }
        public decimal PerDayRate { get; set; }
        public Nullable<int> AvailableStock { get; set; }

        public string Savedata(AddItemModel model)
        {
            string message = "";

            PingladeviEntities db = new PingladeviEntities();
            var getCatData = db.TblAddItems.Where(p => p.ItemNo == model.ItemNo).FirstOrDefault();
            if (getCatData == null)
            { 
                var savedata = new TblAddItem()
                {
                    ItemNo = model.ItemNo,
                    Name = model.Name,
                    PerDayRate = model.PerDayRate,
                    AvailableStock = model.AvailableStock,
                    
                };
                db.TblAddItems.Add(savedata);
                db.SaveChanges();
                return message;
            }
            else
            {
                getCatData.Name = model.Name;
                getCatData.PerDayRate = model.PerDayRate;
                getCatData.AvailableStock = model.AvailableStock;

                db.SaveChanges();
                message = "Update Succesfully";
                return message;
            }
        }
        public List<AddItemModel> GetList()
        {
            PingladeviEntities db = new PingladeviEntities();
            List<AddItemModel> LstCategory = new List<AddItemModel>();
            var Itemssd = db.TblAddItems.ToList();
            if (Itemssd != null)
            {
                foreach (var Category in Itemssd)
                {
                    LstCategory.Add(new AddItemModel()
                    {
                        ItemNo = Category.ItemNo,
                        Name = Category.Name,
                        PerDayRate = Category.PerDayRate,
                        AvailableStock = Category.AvailableStock,

                    });
                }
            }
            return LstCategory;
        }

        public string deleteItem(int id)
        {
            string Message = "";
            PingladeviEntities Db = new PingladeviEntities();
            var deleteRecord = Db.TblAddItems.Where(p => p.ItemNo == id).FirstOrDefault();
            if (deleteRecord != null)
            {
                Db.TblAddItems.Remove(deleteRecord);
            };
            Db.SaveChanges();
            Message = "Item Deleted Successfully";
            return Message;
        }
        public AddItemModel EditData(int id)
        {
            string message = "";
            AddItemModel model = new AddItemModel();
            PingladeviEntities Db = new PingladeviEntities();
            var editData = Db.TblAddItems.Where(p => p.ItemNo == id).FirstOrDefault();
            if (editData != null)
            {
                model.ItemNo = editData.ItemNo;
                model.Name = editData.Name;
                model.PerDayRate = editData.PerDayRate;
                model.AvailableStock = editData.AvailableStock;

            }
            message = "Record Edit Successfully";
            return model;
        }
        public List<AddItemModel> GetItemDDLList()
        {
            PingladeviEntities db = new PingladeviEntities();
            List<AddItemModel> LstCategory = new List<AddItemModel>();
            var Itemssd = db.TblAddItems.ToList();
            if (Itemssd != null)
            {
                foreach (var Category in Itemssd)
                {
                    LstCategory.Add(new AddItemModel()
                    {
                        ItemNo = Category.ItemNo,
                        Name = Category.Name,
                    });
                }
            }
            return LstCategory;
        }
    }
}
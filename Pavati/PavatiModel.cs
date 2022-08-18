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
    public class PavatiModel
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Name { get; set; }
        public string Mobileno { get; set; }
        public string PaymentInWord { get; set; }
        public string PaymentInNo { get; set; }
        public string DateString { get; set; }
        public string SavePavati(PavatiModel model)
        {
            string msg = "";
            PingladeviEntities Db = new PingladeviEntities();
            {
                var savePavati = new Tbl_Pavati()
                {
                    Id = model.Id,
                    Date = model.Date,
                    Name = model.Name,
                    Mobileno = model.Mobileno,
                    PaymentInWord = model.PaymentInWord,
                    PaymentInNo = model.PaymentInNo,
                };
                Db.Tbl_Pavati.Add(savePavati);
                Db.SaveChanges();
                msg = savePavati.Id.ToString();
                return msg;

            }
        }

        public PavatiModel DetailData(int Id)
        {
            string msg = "";
            PavatiModel model = new PavatiModel();
            PingladeviEntities Db = new PingladeviEntities();
            var editData = Db.Tbl_Pavati.Where(p => p.Id == Id).FirstOrDefault();
            if (editData != null)
            {
                model.Id = editData.Id;
                model.DateString = editData.Date.ToString("MM/dd/yyy");
                model.Name = editData.Name;
                model.Mobileno = editData.Mobileno;
                model.PaymentInWord = editData.PaymentInWord;
                model.PaymentInNo = editData.PaymentInNo;
            }
            msg = "";
            return model;
        }
        public List<PavatiModel> GetPavatiList(String FromDate, String ToDate)
        {
            try
            {
                List<PavatiModel> model = new List<PavatiModel>();
                PingladeviEntities db = new PingladeviEntities();
                DataTable dtTable = new DataTable();
                using (var cmd = db.Database.Connection.CreateCommand())
                {
                    try
                    {
                        db.Database.Connection.Open();
                        cmd.CommandText = "usp_GetPavati2Search";
                        cmd.CommandType = CommandType.StoredProcedure;

                        DbParameter parfromd = cmd.CreateParameter();
                        parfromd.ParameterName = "FromDate";
                        parfromd.Value = FromDate;
                        cmd.Parameters.Add(parfromd);

                        DbParameter partod = cmd.CreateParameter();
                        partod.ParameterName = "ToDate";
                        partod.Value = ToDate;
                        cmd.Parameters.Add(partod);

                        DbDataAdapter da = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dtTable);
                        db.Database.Connection.Close();





                        foreach (DataRow dr in dtTable.Rows)
                        {
                            DateTime? createdDate = null;
                            try
                            {
                                createdDate = Convert.ToDateTime(dr["Date"].ToString());
                            }
                            catch
                            {

                            }
                            model.Add(new PavatiModel()
                            {
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                DateString = Convert.ToDateTime(dr["Date"].ToString()).ToString("MM/dd/yyyy"),
                                Name = dr["Name"].ToString(),
                                Mobileno = dr["Mobileno"].ToString(),
                                PaymentInWord = dr["PaymentInWord"].ToString(),
                                PaymentInNo = dr["PaymentInno"].ToString(),

                            });
                        }


                    }
                    catch (Exception ex)
                    {
                        db.Database.Connection.Close();
                        throw ex;
                    }
                }
                db.Dispose();
                return model.ToList();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


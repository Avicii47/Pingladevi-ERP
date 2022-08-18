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
    public class Pavati2model
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Name { get; set; }
        public string Mobileno { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Unit { get; set; }

        public string DateString { get; set; }
        public string SavePavati(Pavati2model model)
        {
            string msg = "";
            PingladeviEntities db = new PingladeviEntities();
            {
                var savePavati = new Tbl_Pavati2()
                {
                    Id = model.Id,
                    Date = model.Date,
                    Name = model.Name,
                    Mobileno = model.Mobileno,
                    Category = model.Category,
                    SubCategory = model.SubCategory,
                    Unit = model.Unit,
                };
                db.Tbl_Pavati2.Add(savePavati);
                db.SaveChanges();
                msg = savePavati.Id.ToString();
               // return msg;

            }
            string mobile = model.Mobileno;
            string sAPIKey = "fYMsEmpZQUewatTPf0TktQ";
            string sNumber = mobile;
            string sMessage = "Hi, " + model.Name + "  Thank you For Donation of  " + model.SubCategory + ", Pingladevi.in";
            string sSenderId = "BSCAKE";
            string sChannel = "trans";
            string sRoute = "8";
            string sURL = "http://mysms.msg24.in/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderId + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "&route=" + sRoute + "";

            string sResponse = GetResponse(sURL);

            return msg;
        }
        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public Pavati2model DetailData(int Id)
        {
            string msg = "";
            Pavati2model model = new Pavati2model();
            PingladeviEntities Db = new PingladeviEntities();
            var editData = Db.Tbl_Pavati2.Where(p => p.Id == Id).FirstOrDefault();
            if (editData != null)
            {
                model.Id = editData.Id;
                model.DateString = editData.Date.ToString("MM/dd/yyy");
                model.Name = editData.Name;
                model.Mobileno = editData.Mobileno;
                model.Category = editData.Category;
                model.SubCategory = editData.SubCategory;
                model.Unit = editData.Unit;
            }
            msg = "";
            return model;
        }
        public List<Pavati2model>GetPavati2List(String FromDate, String ToDate)
        {
            try
            {
                List<Pavati2model> model = new List<Pavati2model>();
                PingladeviEntities db = new PingladeviEntities();
                DataTable dtTable = new DataTable();
                using (var cmd = db.Database.Connection.CreateCommand())
                {
                    try
                    {
                        db.Database.Connection.Open();
                        cmd.CommandText = "usp_GetPavatiSearch";
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
                            model.Add(new Pavati2model()
                            {
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                DateString = Convert.ToDateTime(dr["Date"].ToString()).ToString("MM/dd/yyyy"),
                                Name = dr["Name"].ToString(),
                                Mobileno = dr["Mobileno"].ToString(),
                                Category = dr["Category"].ToString(),
                                SubCategory = dr["SubCategory"].ToString(),
                                Unit = dr["Unit"].ToString(),

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

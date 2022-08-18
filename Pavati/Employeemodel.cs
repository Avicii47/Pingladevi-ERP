using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pingladevi.Data;

namespace Pingladevi.Models
{
    public class Employeemodel
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpMibileno { get; set; }
        public string EmpEmail { get; set; }
        public string EmpCity { get; set; }
        public string EmpQualification { get; set; }
        public string EmpDesignation { get; set; }

        public string Salary { get; set; }
        public string JobType { get; set; }

        public string SaveEmployee(Employeemodel model)
        {
            string msg = "";
            PingladeviEntities Db = new PingladeviEntities();
            {
                var saveEmployee = new Tbl_Employee()
                {
                    EmpID = model.EmpID,
                    EmpName = model.EmpName,
                    EmpAddress = model.EmpAddress,
                    EmpMibileno = model.EmpMibileno,
                    EmpEmail = model.EmpEmail,
                    EmpCity = model.EmpCity,
                    EmpQualification = model.EmpQualification,
                    EmpDesignation = model.EmpDesignation,
                    Salary = model.Salary,
                    JobType = model.JobType,
                };
                Db.Tbl_Employee.Add(saveEmployee);
                Db.SaveChanges();
                msg = saveEmployee.EmpID.ToString();
                return msg;

            }
        }
        public List<Employeemodel>GetEmployeeList()
        {
            PingladeviEntities Db = new PingladeviEntities();
            List<Employeemodel> lstEmployee = new List<Employeemodel>();
            var AddEmployeeList = Db.Tbl_Employee.ToList();
            if (AddEmployeeList != null)
            {
                foreach (var Employee in AddEmployeeList)
                {
                    lstEmployee.Add(new Employeemodel()
                    {
                        EmpID = Employee.EmpID,
                        EmpName = Employee.EmpName,
                        EmpAddress = Employee.EmpAddress,
                        EmpMibileno = Employee.EmpMibileno,
                        EmpEmail = Employee.EmpEmail,
                        EmpCity = Employee.EmpCity,
                        EmpQualification = Employee.EmpQualification,
                        EmpDesignation = Employee.EmpDesignation,
                        Salary = Employee.Salary,
                        JobType = Employee.JobType,

                    });
                }
            }
        
            return lstEmployee;
        }

    }
}
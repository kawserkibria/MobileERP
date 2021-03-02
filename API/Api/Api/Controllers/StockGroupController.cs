﻿using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Api.Controllers
{
    public class StockGroupController : ApiController
    {
        OTP.SWAPIClient objW = new OTP.SWAPIClient();

        public IHttpActionResult Get()
        {
            //string values = objW.mLoadStockGroup("0002");
            List<OTP.Stockgroup> objGroup = objW.mLoadStockGroup("0003").ToList();
            

            //List<customer> customerList = new List<customer>();
            //customer customer1 = new customer()
            //{
            //    EmpID = 1,
            //    EmpName = "Sourabh",
            //    EmpSalary = 50000
            //};
            //customer customer2 = new customer()
            //{
            //    EmpID = 2,
            //    EmpName = "Shaili",
            //    EmpSalary = 60000
            //};
            //customer customer3 = new customer()
            //{
            //    EmpID = 3,
            //    EmpName = "Saloni",
            //    EmpSalary = 55000
            //};


            //customerList.Add(customer1);
            //customerList.Add(customer2);
            //customerList.Add(customer3);

            //JsonConvert.SerializeObject(customerList);
            return Json(objGroup);

        }

    }
    //public class customer
    //{
    //    public int EmpID { get; set; }
    //    public string EmpName { get; set; }
    //    public int EmpSalary { get; set; }

    //}  
}

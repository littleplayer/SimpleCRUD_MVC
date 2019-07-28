using CRUD.Object.CRUD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create(string Name = "NoData", int Age = 0)
        {
            CRUDHelper.Create(Name, Age);
            //Retrieve();
            Delete();
            return View();
        }

        public ActionResult Retrieve()
        {
            List<CRUDModel> List = new List<CRUDModel>();
            List = CRUDHelper.Retrieve();
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public  ActionResult Delete(string Name = "NoData")
        {
            Retrieve();
            Name = "Bob";
            CRUDHelper.Delete(Name);
            Retrieve();
            return View();
        }
    }
}